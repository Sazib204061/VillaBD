using Microsoft.AspNetCore.Mvc;
using VillaBD.Domain.Entities;
using VillaBD.Infrastructure.Data;
namespace VillaBD.Web.Controllers
{
    public class VillaController : Controller
    {

        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa newVilla)
        {
            if (newVilla.Name == newVilla.Description)
            {
                ModelState.AddModelError("name", "The Descriptioin cannot exactly match the Name.");
                ModelState.AddModelError("Description", "The Descriptioin cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(newVilla);
                _db.SaveChanges();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction("Index", "Villa");
            }
            else
            {
                TempData["error"] = "The villa could not be created.";
                return View();
            }
        }

        public IActionResult Update(int villaId)
        {
            Villa? oldVilla = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            //when we need retrive multiple row based on condition we can use Where method
            //var VillaList = _db.Villas.Where(u => u.Price < 400 && u.Occupancy > 2);
            if (oldVilla==null)
            {
                return NotFound();
            }
            return View(oldVilla);
        }

        [HttpPost]
        public IActionResult Update(Villa updatedVilla)
        {
            if (updatedVilla.Name == updatedVilla.Description)
            {
                ModelState.AddModelError("name", "The Descriptioin cannot exactly match the Name.");
                ModelState.AddModelError("Description", "The Descriptioin cannot exactly match the Name.");
            }
            if (ModelState.IsValid && updatedVilla.Id>0)
            {
                _db.Villas.Update(updatedVilla);
                _db.SaveChanges();
                TempData["success"] = "The villa has been updated successfylly.";
                return RedirectToAction("Index", "Villa");
            }
            TempData["error"] = "The villa could not be updated.";
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? villa = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            if(villa == null)
            {
                return NotFound();
            }
            return View(villa);
        }
        [HttpPost]
        public IActionResult Delete(Villa deletedVilla)
        {
            Villa? villa = _db.Villas.FirstOrDefault(u => u.Id == deletedVilla.Id);
            if(villa is not null)
            {
                _db.Villas.Remove(villa);
                _db.SaveChanges();
                TempData["success"] = "The villa has been deleted successfully.";
                return RedirectToAction("Index", "Villa");
            }
            TempData["error"] = "The villa could not be deleted.";
            return View();
        }
    }
}

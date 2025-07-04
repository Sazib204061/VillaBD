using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if(newVilla.Name==newVilla.Description)
            {
                ModelState.AddModelError("name", "The Descriptioin cannot exactly match the Name.");
                ModelState.AddModelError("Description", "The Descriptioin cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(newVilla);
                _db.SaveChanges();
                return RedirectToAction("Index", "Villa");
            }
            else
            {
                return View();
            }
        }
    }
}

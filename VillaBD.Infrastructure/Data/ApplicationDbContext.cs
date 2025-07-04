using Microsoft.EntityFrameworkCore;
using VillaBD.Domain.Entities;

namespace VillaBD.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Villa1",
                    Description = "Descreption of Villa1",
                    ImageUrl = "https://placehold.co/600x400",
                    Occupancy = 4,
                    Price = 200,
                    Sqft = 550
                },
                new Villa
                {
                    Id = 2,
                    Name = "Villa2",
                    Description = "Descreption of Villa2",
                    ImageUrl = "https://placehold.co/600x4001",
                    Occupancy = 4,
                    Price = 300,
                    Sqft = 550
                },
                new Villa
                {
                    Id = 3,
                    Name = "Villa3",
                    Description = "Descreption of Villa3",
                    ImageUrl = "https://placehold.co/600x4002",
                    Occupancy = 4,
                    Price = 400,
                    Sqft = 550
                }

            );
        }
    }
}

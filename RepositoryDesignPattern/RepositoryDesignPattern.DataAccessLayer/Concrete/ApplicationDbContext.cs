using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.EntityLayer.Concrete;
using System.Linq;

namespace RepositoryDesignPattern.DataAccessLayer.Concrete
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public void SeedData()
        {
            if (!Categories.Any()) 
            {
                Categories.AddRange(
                    new Category { CategoryName = "Elektronik" },
                    new Category { CategoryName = "Giyim" },
                    new Category { CategoryName = "Ev Aletleri" }
                );
                SaveChanges();
            }

            if (!Products.Any()) 
            {
                Products.AddRange(
                    new Product { ProductName = "Laptop", ProductStock = 50, ProductPrice = 12000.50M, CategoryID = 1 },
                    new Product { ProductName = "Telefon", ProductStock = 100, ProductPrice = 8500.00M, CategoryID = 1 },
                    new Product { ProductName = "Tişört", ProductStock = 200, ProductPrice = 100.00M, CategoryID = 2 },
                    new Product { ProductName = "Buzdolabı", ProductStock = 30, ProductPrice = 7500.99M, CategoryID = 3 }
                );
                SaveChanges();
            }
        }

    }
}

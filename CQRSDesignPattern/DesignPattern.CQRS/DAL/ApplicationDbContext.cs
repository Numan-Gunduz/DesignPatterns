using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        // Veritabanı başlangıç verilerini ekler
        public void SeedData()
        {
            if (!Products.Any())
            {
                Products.AddRange(
                    new Product { Name = "Laptop", Stock = 50, Price = 12000.50M, Description = "Yüksek performanslı dizüstü bilgisayar", Status = true },
                    new Product { Name = "Mouse", Stock = 150, Price = 150.75M, Description = "Ergonomik tasarımlı kablosuz mouse", Status = true },
                    new Product { Name = "Klavye", Stock = 80, Price = 300.00M, Description = "Mekanik klavye RGB ışıklandırmalı", Status = true },
                    new Product { Name = "Monitör", Stock = 40, Price = 2500.99M, Description = "27 inç 4K UHD monitör", Status = true },
                    new Product { Name = "Telefon", Stock = 100, Price = 8500.00M, Description = "Amiral gemisi akıllı telefon", Status = true },
                    new Product { Name = "Kulaklık", Stock = 200, Price = 500.25M, Description = "Kablosuz bluetooth kulaklık", Status = true },
                    new Product { Name = "SSD", Stock = 120, Price = 1000.75M, Description = "1TB NVMe SSD depolama", Status = true },
                    new Product { Name = "Çanta", Stock = 70, Price = 200.99M, Description = "Laptop için su geçirmez sırt çantası", Status = true },
                    new Product { Name = "Hoparlör", Stock = 90, Price = 750.50M, Description = "Bluetooth taşınabilir hoparlör", Status = true },
                    new Product { Name = "Webcam", Stock = 60, Price = 400.00M, Description = "1080p çözünürlükte webcam", Status = true }
                );

                SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Başlangıç verilerini Migration ile eklemek isterseniz burayı kullanabilirsiniz
        }
    }
}

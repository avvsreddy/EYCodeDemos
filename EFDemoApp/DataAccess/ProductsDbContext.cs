using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFDemoApp.DataAccess
{
    public class ProductsDbContext : DbContext
    {

        // configure the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProductsCatalogEY2023;Integrated Security=True");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            // install package : Microsoft.EntityFrameworkCore.Proxies
            optionsBuilder.UseLazyLoadingProxies(true);

        }

        // configure the tables
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Person> People { get; set; }
    }
}

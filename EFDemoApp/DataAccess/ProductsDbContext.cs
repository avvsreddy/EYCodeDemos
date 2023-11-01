using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDemoApp.DataAccess
{
    public class ProductsDbContext : DbContext
    {

        // configure the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProductsCatalogEY2023;Integrated Security=True");
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        // configure the tables
        public DbSet<Product> Products { get; set; }

    }
}

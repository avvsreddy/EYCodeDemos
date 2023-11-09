using Microsoft.EntityFrameworkCore;

namespace SuperProductsCatalog.Model.Data
{
    public class ProductsDBContext : DbContext
    {
        // config db

        public ProductsDBContext(DbContextOptions<ProductsDBContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}


        // map tables

        public DbSet<Product> Products { get; set; }
    }
}

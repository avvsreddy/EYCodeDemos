using EFDemoApp.DataAccess;
using EFDemoApp.Entities;

namespace EFDemoApp.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept product name and price and save into data




        }

        private static void select1()
        {
            // get all products data from database and display
            ProductsDbContext db = new ProductsDbContext();
            // linq to entities
            var products = from p in db.Products
                           select p;

            foreach (var item in products)
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }
        }

        private static void Save()
        {
            // Create new product and save into db - write pure oo code
            Product p1 = new Product { Name = "IPhone X", Price = 56000 };
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p1);
            db.SaveChanges();
            Console.WriteLine("done");
        }
    }
}
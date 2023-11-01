using EFDemoApp.DataAccess;
using EFDemoApp.Entities;

namespace EFDemoApp.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept product name and price and save into data
            while (true)
            {
                Console.WriteLine("Product Management System");
                Console.WriteLine("===========================");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Display All Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Edit Product");
                Console.WriteLine("6. Exit Application");

                Console.WriteLine("------------------------");
                Console.Write("Enter you option [1-6] :");
                int choice;
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Add(); break;
                    case 2: DisplayAll(); break;
                    case 3: Search(); break;
                    case 4: Delete(); break;
                    case 5: Edit(); break;
                    case 6: break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }



        }

        private static void Edit()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.Write("Enter ProductID to Edit :");
            int id = int.Parse(Console.ReadLine());
            var productToEdit = db.Products.Find(id);
            Console.WriteLine("------------");
            Console.WriteLine(productToEdit.Name);
            Console.WriteLine(productToEdit.Price);
            Console.Write("Enter new price: ");
            int newprice = int.Parse(Console.ReadLine());
            productToEdit.Price = newprice;
            db.SaveChanges();
            Console.WriteLine("Modified...");

        }

        private static void Delete()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.Write("Enter ProductID to delete :");
            int id = int.Parse(Console.ReadLine());
            var productToDel = db.Products.Find(id);
            db.Products.Remove(productToDel);
            db.SaveChanges();
            Console.WriteLine("Deleted...");
        }

        private static void Search()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.Write("Enter ProductID to search :");
            int id = int.Parse(Console.ReadLine());
            //var product = (from p in db.Products
            //               where p.ProductID == id
            //               select p).FirstOrDefault();

            var product = db.Products.Find(id);

            if (product == null)
                Console.WriteLine("Product not found");
            else
            {
                Console.WriteLine("Product ID \t Name \t Price");
                Console.WriteLine($"{product.ProductID}\t{product.Name}\t{product.Price}");
            }
        }

        private static void DisplayAll()
        {
            ProductsDbContext db = new ProductsDbContext();
            Console.WriteLine("Product ID \t Name \t Price");
            foreach (var item in db.Products)
            {
                Console.WriteLine($"{item.ProductID}\t{item.Name}\t{item.Price}");
            }
        }

        public static void Add()
        {
            Product p = new Product();
            Console.Write("Enter Product Name :");
            p.Name = Console.ReadLine();
            Console.Write("Enter Price :");
            p.Price = int.Parse(Console.ReadLine());
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            db.SaveChanges();
        }


    }
}
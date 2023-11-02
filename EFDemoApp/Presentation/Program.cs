using EFDemoApp.DataAccess;
using EFDemoApp.Entities;

namespace EFDemoApp.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get all products and display pname and cname
            ProductsDbContext db = new ProductsDbContext();
            // egar loading - include
            //var allProducts = db.Products.Include(p => p.Category).ToList();
            var allProducts = db.Products.ToList();
            //display
            foreach (var item in allProducts)
            {
                Console.WriteLine($"{item.Name}\t{item.Category.Name}");
            }

        }

        private static void NewMethod2()
        {
            ProductsDbContext db = new ProductsDbContext();
            // add new product into existing catagory
            Product p = new Product { Name = "Galaxy S23 Pro", Brand = "Samsung", Price = 155000 };

            var c = db.Categories.Find(1);
            // associate p with c
            p.Category = c;
            db.Products.Add(p);
            //db.Categories.Add(c);
            db.SaveChanges();
        }

        private static void NewMethod1()
        {
            // Add new product into new category
            Category c = new Category { Name = "Mobiles" };

            Product p = new Product
            {
                Name = "IPhone X",
                Brand = "Apple",
                Price = 90000,
                Category = c
            };

            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            //db.Categories.Add(c);

            db.SaveChanges();
        }

        public static void Menu()
        {
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
                Console.WriteLine("Product ID \t Name \t Price \t Brand");
                Console.WriteLine($"{product.ProductID}\t{product.Name}\t{product.Price}\tBrand");
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
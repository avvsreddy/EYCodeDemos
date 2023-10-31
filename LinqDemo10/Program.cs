namespace LinqDemo10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get all products name belongs to brand apple
            var appleProducts = from p in ProductsDB.GetProducts()
                                where p.Brand == "Apple"
                                select p.Name;

            foreach (var item in appleProducts)
            {
                //Console.WriteLine(item);
            }

            // get all products name and category name then display
            // sql: select p.name,c.name from products p join category c on p.id = c.id

            var pnamecname = from p in ProductsDB.GetProducts()
                             select new { PName = p.Name, CName = p.Category.Name };

            foreach (var item in pnamecname)
            {
                Console.WriteLine(item.PName + " " + item.CName);
            }


            // get the first product
            var firstProduct = (from p in ProductsDB.GetProducts()
                                select p).First();

            var firstP = ProductsDB.GetProducts().First();


        }
    }



    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }

    public static class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            Product p1 = new Product { ID = 111, Name = "IPhone X", Brand = "Apple", Country = "India", Price = 75000 };
            Product p2 = new Product { ID = 222, Name = "IPhone 11", Brand = "Apple", Country = "India", Price = 79000 };
            Product p3 = new Product { ID = 333, Name = "IPhone 12", Brand = "Apple", Country = "India", Price = 85000 };
            Product p4 = new Product { ID = 444, Name = "Galaxy S23", Brand = "Samsung", Country = "China", Price = 65000 };
            Product p5 = new Product { ID = 555, Name = "IWatch", Brand = "Apple", Country = "China", Price = 65000 };


            Category c1 = new Category { ID = 1, Name = "Mobiles" };
            c1.Products.Add(p1);
            c1.Products.Add(p2);
            c1.Products.Add(p3);
            c1.Products.Add(p4);

            Category c2 = new Category { ID = 2, Name = "Smart Watch" };
            c2.Products.Add(p5);

            p1.Category = c1;
            p2.Category = c1;
            p3.Category = c1;
            p4.Category = c1;
            p5.Category = c2;

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
}
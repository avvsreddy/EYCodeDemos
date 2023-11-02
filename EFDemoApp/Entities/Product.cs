using System.ComponentModel.DataAnnotations;

namespace EFDemoApp.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Brand { get; set; }
        public int Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}

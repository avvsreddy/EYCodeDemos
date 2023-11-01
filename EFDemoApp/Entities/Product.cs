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
        public Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }


}

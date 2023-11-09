namespace SuperProductsCatalog.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public bool IsAvailable { get; set; }

    }
}

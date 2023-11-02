using EFDemoApp.Entities;

namespace EFDemoApp.DataAccess
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsDbContext db = new ProductsDbContext();
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public void Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}

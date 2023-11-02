using EFDemoApp.Entities;

namespace EFDemoApp.DataAccess
{
    public interface IProductsRepository
    {
        void Save(Product product);
        //void Delete(int id);
        List<Product> GetAll();
        Product GetById(int id);

        void Update(Product product);


    }
}

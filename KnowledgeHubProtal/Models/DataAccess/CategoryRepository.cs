using KnowledgeHubProtal.Models.Domain;

namespace KnowledgeHubProtal.Models.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly KHPDbContext db = new KHPDbContext();
        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return db.Categories.Find(id);
        }

        public List<Category> GetByName(string name)
        {
            var cat = (from c in db.Categories
                       where c.CategoryName.Contains(name)
                       select c);
            return cat.ToList();
        }

        public void Update(Category category)
        {
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}

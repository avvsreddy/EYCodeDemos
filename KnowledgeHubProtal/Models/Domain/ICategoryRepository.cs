namespace KnowledgeHubProtal.Models.Domain
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        List<Category> GetByName(string name);
        void Create(Category category);
        void Update(Category category);



    }
}

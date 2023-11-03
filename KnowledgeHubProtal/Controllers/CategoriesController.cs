using KnowledgeHubProtal.Models.DataAccess;
using KnowledgeHubProtal.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KnowledgeHubProtal.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryRepository repo = new CategoryRepository();


        //.../Categories/Index
        public IActionResult Index(string term)
        {
            List<Category> categories = null;
            if (term.IsNullOrEmpty())
            {
                categories = repo.GetAll();
            }
            else
            {
                categories = repo.GetByName(term);
            }

            return View(categories);

            // return list of categories

        }
    }
}

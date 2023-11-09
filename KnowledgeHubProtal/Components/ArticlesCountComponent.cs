using KnowledgeHubProtal.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubProtal.Components
{
    public class ArticlesCountViewComponent : ViewComponent
    {
        private KHPDbContext db;
        public ArticlesCountViewComponent(KHPDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            // get articles count and return to view
            int count = db.Articles.Where(a => a.IsApproved).Count();
            //ViewBag.Count = count;
            return View(count);
        }


    }
}

using KnowledgeHubProtal.Models.DataAccess;
using KnowledgeHubProtal.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubProtal.Controllers
{
    public class ArticlesController : Controller
    {
        // use DI
        ICategoryRepository cRepo;// = new CategoryRepository();
        KHPDbContext db;// = new KHPDbContext();

        public ArticlesController(ICategoryRepository repo, KHPDbContext db)
        {
            this.cRepo = repo;
            this.db = db;
        }


        public IActionResult Index() // list-display the data
        {
            var approvedArticles = from a in db.Articles
                                   where a.IsApproved == true
                                   select a;
            return View(approvedArticles.ToList());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Submit()
        {
            //return View with category list
            // fetch the categories

            var categories = cRepo.GetAll();
            ViewBag.Categories = categories;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Submit(Article article)
        {
            // server side validation

            article.DateSubmited = DateTime.Now;
            article.Author = User.Identity.Name;
            //article.Author = "Unknown";
            article.IsApproved = false;

            //if (!ModelState.IsValid)
            //{
            //    var categories = cRepo.GetAll();
            //    ViewBag.Categories = categories;
            //    return View();
            //}
            db.Articles.Add(article);
            db.SaveChanges();

            TempData["Message"] = $"Article {article.Title} is sumitted successfully";

            return RedirectToAction("Submit");



        }
        [Authorize(Roles = "admin")]
        public IActionResult Review()
        {
            // fetch all new unapproved articles and return to view
            var unapprovedArticles = from a in db.Articles.Include(a => a.Category)
                                     where a.IsApproved == false
                                     select a;
            return View(unapprovedArticles);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Approve(List<int> articlesid)
        {
            //TODO - make it efficient
            var allArticles = db.Articles;
            foreach (var article in allArticles)
            {
                foreach (var id in articlesid)
                {
                    if (article.ArticleID == id)
                    {
                        article.IsApproved = true;
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Review");
        }
        [Authorize(Roles = "admin")]
        public IActionResult Reject(List<int> articlesid)
        {
            //TODO - make it efficient
            var allArticles = db.Articles;
            foreach (var article in allArticles)
            {
                foreach (var id in articlesid)
                {
                    if (article.ArticleID == id)
                    {
                        db.Articles.Remove(article);
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Review");
        }

    }
}

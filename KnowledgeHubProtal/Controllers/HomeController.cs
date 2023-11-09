using KnowledgeHubProtal.Data;
using KnowledgeHubProtal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KnowledgeHubProtal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext adb;
        UserManager<IdentityUser> userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext adb, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.adb = adb;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {


            return View();
        }

        public IActionResult Users()
        {
            //var users = adb.Users.ToList();

            return View(userManager.Users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
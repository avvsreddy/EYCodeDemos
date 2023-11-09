using KnowledgeHubProtal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubProtal.Controllers
{
    public class UsersManagementController : Controller
    {

        ApplicationDbContext adb;
        UserManager<IdentityUser> userManager;

        // DI
        public UsersManagementController(ApplicationDbContext adb, UserManager<IdentityUser> manager)
        {
            this.adb = adb;
            this.userManager = manager;
        }

        public IActionResult Index()
        {

            // display all registerd user
            //var allUsers = adb.Users.ToList();

            var allUsers = userManager.Users.ToList();

            return View(allUsers);
        }
    }
}

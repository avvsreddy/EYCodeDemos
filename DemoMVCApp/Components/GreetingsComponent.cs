using Microsoft.AspNetCore.Mvc;

namespace DemoMVCApp.Components
{
    public class GreetingsComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string msg)
        {
            var data = new List<string>() { "AAA", "BBB", "CCC" };
            ViewBag.Message = msg;
            return View(data);
        }

    }
}

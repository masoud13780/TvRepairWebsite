using Microsoft.AspNetCore.Mvc;

namespace TvRepairWebsite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogMain()
        {
            return View();
        }

        public IActionResult BlogPage()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TvRepairWebsite.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}

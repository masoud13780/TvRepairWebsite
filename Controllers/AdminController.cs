using Microsoft.AspNetCore.Mvc;

namespace TvRepairWebsite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return PartialView("Partials/_Dashboard");
        }

        public IActionResult Products()
        {
            return PartialView("Partials/_Products");
        }

        public IActionResult Articles()
        {
            return PartialView("Partials/_Articles");
        }
        public IActionResult Users()
        {
            return PartialView("Partials/_Users");
        }
        public IActionResult SmsPanel()
        {
            return PartialView("Partials/_SmsPanel");
        }
    }
}

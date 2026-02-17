using Microsoft.AspNetCore.Mvc;

namespace TvRepairWebsite.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}

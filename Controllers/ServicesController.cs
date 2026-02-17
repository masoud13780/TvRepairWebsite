using Microsoft.AspNetCore.Mvc;

namespace TvRepairWebsite.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Services()
        {
            return View();
        }
    }
}

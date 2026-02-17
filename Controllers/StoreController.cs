using Microsoft.AspNetCore.Mvc;

namespace TvRepairWebsite.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Store()
        {
            return View();
        }
    }
}

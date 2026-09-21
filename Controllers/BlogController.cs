using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Repository;

namespace TvRepairWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        public BlogController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }




        public IActionResult BlogMain()
        {
            var bloges = 
                _articleRepository.GetAllArticles();

            return View(bloges);
        }

        [HttpGet]
        public IActionResult FlatBreak()
        {
            return View();
        }
        public IActionResult Water()
        {
            return View();
        }
        public IActionResult PowerOff()
        {
            return View();
        }
        public IActionResult PowerLight()
        {
            return View();
        }
        public IActionResult PowerOffReason()
        {
            return View();
        }
        public IActionResult SuddenTvOff()
        {
            return View();
        }
        public IActionResult TvDimScreen()
        {
            return View();
        }
        public IActionResult TVNoPicture()
        {
            return View();
        }


    }
}

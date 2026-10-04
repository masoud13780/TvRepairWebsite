using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Models;
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

        [Authorize]
        public IActionResult BlogPage(int id)
        {
            //بدست آوردن کاربر برای ذخیره لاگ دیدن مقاله
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (!UserId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            ArticleView articleView = new ArticleView()
            {
                UserId = UserId.Value,
                ArticleId = id,
                ViewedAt = DateTime.Now
            };

            //ثبت ویو مقاله
            _articleRepository.InsertArticleView(articleView);

            //بدست آوردن مقاله
            var article = _articleRepository.GetArticle(id);

            return View(article);
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

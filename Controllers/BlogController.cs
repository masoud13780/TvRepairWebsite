using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Models;
using TvRepairWebsite.Repository;
using TvRepairWebsite.Services;

namespace TvRepairWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IDiscountCodeRepository _codeRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IDiscountCodeService _codeServices;
        public BlogController(IArticleRepository articleRepository, IDiscountCodeRepository codeRepository, ICommentRepository commentRepository, IDiscountCodeService codeServices)
        {
            _articleRepository = articleRepository;
            _codeRepository = codeRepository;
            _commentRepository = commentRepository;
            _codeServices = codeServices;
        }

        
        public IActionResult BlogPage(int ArticleId)
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
                ArticleId = ArticleId,
                ViewedAt = DateTime.Now
            };
            //ثبت ویو مقاله
            _articleRepository.InsertArticleView(articleView);
            _articleRepository.Save();

             string? discountCode = _codeServices.CheckAndCreateDiscountAsync(UserId.Value);
            // اگر کد تخفیفی تعلق گرفت، ذخیره در TempData برای نمایش بعد از ریدایرکت
            if (!string.IsNullOrEmpty(discountCode))
            {
                TempData["NewDiscountCode"] = discountCode;
            }
            //بدست آوردن مقاله
            var article = _articleRepository.GetArticle(ArticleId);

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

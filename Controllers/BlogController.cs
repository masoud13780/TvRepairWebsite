using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Models;
using TvRepairWebsite.Repository;

namespace TvRepairWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IDiscountCodeRepository _codeRepository;
        private readonly ICommentRepository _commentRepository;
        public BlogController(IArticleRepository articleRepository, IDiscountCodeRepository codeRepository, ICommentRepository commentRepository)
        {
            _articleRepository = articleRepository;
            _codeRepository = codeRepository;
            _commentRepository = commentRepository;
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
            //*اگر کاربر کد تخفیف نداشت باید چک کنیم ایا دو مقاله خونده و یک نظر
            //که کد تخفیف براش ایجاد بشه*//
            bool ExistDiscountCode = _codeRepository.ExistCodeForUser(UserId.Value);
            if (!ExistDiscountCode)
            {
                //کاربر تاحالا کد تخفیف نگرفته
                //آیا تا الان دو مقاله دیده؟
                //آیا کامنتی گذاشته؟
                bool Exist_Article_View = _articleRepository.ViewTwoArticle(UserId.Value);
                bool Exist_Comment = _commentRepository.ExistCommentForUser(UserId.Value);

                if(Exist_Article_View && Exist_Comment)
                {
                    //یک کد تخفیف باید ایجاد بشه
                    //و یک فیلد هم مثلا برای
                }

            }






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

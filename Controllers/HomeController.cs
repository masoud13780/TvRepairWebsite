using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;
using TvRepairWebsite.Models.ViewModels;
using TvRepairWebsite.Services;

namespace TvRepairWebsite.Controllers
{
    public class HomeController : Controller
    {

        private readonly TvRepairWebSiteDbContext _contex;
        private readonly IDiscountCodeService _codeServices;
        public HomeController(TvRepairWebSiteDbContext cntx, IDiscountCodeService codeServices)
        {
            _contex = cntx;
            _codeServices = codeServices;
        }

        //صفحه اصلی
        [HttpGet]
        public IActionResult Index()
        {

            var UserId = HttpContext.Session.GetInt32("UserId");

            //لیست نظرات
            List<Comment> comments = _contex.Comments.ToList();
            //لیست محصولات
            List<Product> products = _contex.products.ToList();
            //لیست مقالات
            List<Article> articles = _contex.Articles.ToList();


            var HomeVM = new HomeVM
            {
                user = _contex.Users.FirstOrDefault(u => u.UserId == UserId),
                Comments = comments,
                Products = products,
                Articles = articles
            };


            return View(HomeVM);
        }

        [HttpPost]
        public IActionResult Index(HomeVM data)
        {
            var comment = data.CreateComment;
            comment.CreateDate = DateTime.Now;

            try
            {

                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                    return RedirectToAction("Login", "Account");

                //ثبت نظر
                Comment commentdb = new Comment()
                {
                    FullName = comment.FullName,
                    Phone = comment.Phone,
                    Description = comment.Description,
                    CreateDate = comment.CreateDate,
                    Rate = comment.Rate,
                    UserId = userId
                };

                _contex.Comments.Add(commentdb);
                _contex.SaveChanges();

                string? discountCode = _codeServices.CheckAndCreateDiscountAsync(userId.Value);
                // اگر کد تخفیفی تعلق گرفت، ذخیره در TempData برای نمایش بعد از ریدایرکت
                if (!string.IsNullOrEmpty(discountCode))
                {
                    TempData["NewDiscountCode"] = discountCode;
                }

                ModelState.AddModelError("", "نظر شما با موفقیت ثبت گردید");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در ثبت اطلاعات رخ داده است. دوباره تلاش کنید.");
                Console.WriteLine(ex);
                return View(comment);
            }

        }



    }
}

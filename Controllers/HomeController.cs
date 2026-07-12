using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;
using TvRepairWebsite.Models.ViewModels;

namespace TvRepairWebsite.Controllers
{
    public class HomeController : Controller
    {

        private readonly TvRepairWebSiteDbContext _contex;
        public HomeController(TvRepairWebSiteDbContext cntx)
        {
            _contex = cntx;
        }

        //صفحه اصلی
        [HttpGet]
        public IActionResult Index()
        {
            //لیست نظرات
            List<Comment> comments = _contex.Comments.ToList();
            //لیست محصولات
            List<Product> products = _contex.products.ToList();
            //لیست مقالات
            List<Article> articles = _contex.Articles.ToList();



            var HomeVM = new HomeVM
            {
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
                //ثبت نظر
                Comment commentdb = new Comment()
                {
                    FullName = comment.FullName,
                    Phone = comment.Phone,
                    Description = comment.Description,
                    CreateDate = comment.CreateDate,
                    Rate = comment.Rate
                };

                _contex.Comments.Add(commentdb);
                _contex.SaveChanges();

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

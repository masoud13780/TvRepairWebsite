using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;
using TvRepairWebsite.Models.ViewModels;

namespace TvRepairWebsite.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly TvRepairWebSiteDbContext _contex;
        public ContactUsController(TvRepairWebSiteDbContext context)
        {
            _contex = context;
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsVM contactUs)
        {
            contactUs.CraeteDate = DateTime.Now;

            //if (!ModelState.IsValid)
            //    return View(contactUs);

            try
            {

                ContactUs contactDd = new ContactUs()
                {
                    FullName = contactUs.FullName,
                    EmailOrPhone = contactUs.EmailOrPhone,
                    Subject = contactUs.Subject,
                    Message = contactUs.Message,
                    CraeteDate = contactUs.CraeteDate
                };


                _contex.contactUs.Add(contactDd);
                _contex.SaveChanges();
                ModelState.AddModelError("", "اطلاعات شما با موفقیت ثبت گردید در سریعترین زمان ممکن با شما ارتباط می‌گیریم");

                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطا در ثبت اطلاعات");
                return View(contactUs);
            }
        }
    }
}

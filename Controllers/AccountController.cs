using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;
using TvRepairWebsite.Models.ViewModels;
using TvRepairWebsite.Repository;

namespace TvRepairWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly  TvRepairWebSiteDbContext _contex;
        public AccountController(TvRepairWebSiteDbContext cntx)
        {
            _contex = cntx;
        }


        #region ورود 

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserVM loginUser)
        {
            if (!ModelState.IsValid)
                return View(loginUser);

            try
            {
                User user = _contex.Users.FirstOrDefault(x => x.Phone == loginUser.Phone);
                if(user == null)
                {
                    ModelState.AddModelError("", "کاربری با این شماره همراه موجود نمی‌باشد");
                    return View(loginUser);
                }

                if(user.Password != loginUser.Password)
                {
                    ModelState.AddModelError("Password", "رمز عبور اشتباه است");
                    return View(loginUser);
                }

                if (user.Password == loginUser.Password)
                {
                    //ذخیره کاربر در سشن
                    HttpContext.Session.SetString("PhoneUser", user.Phone);
                    HttpContext.Session.SetString("Admin", user.Admin.ToString());
                    return RedirectToAction("Index", "Home");

                }


            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "خطایی در ثبت اطلاعات رخ داده است. دوباره تلاش کنید.");
                Console.WriteLine(ex);
                return View(loginUser);
            }



            return View();
        }

        #endregion

        #region عضویت

        [HttpGet]
        public IActionResult Membership()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Membership(CreateUserVM user)
        {
            if (!ModelState.IsValid)            
                return View(user);

            try
            {
                User findUser = _contex.Users.FirstOrDefault(x=> x.Phone == user.Phone);
                if (findUser != null)
                {
                    ModelState.AddModelError("", "کاربری با این شماره موجود است");
                    return View(user);  
                }

                User userdb = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Password = user.Password,
                    RePassword = user.RePassword,
                    TVType = user.TVType
                };

                _contex.Users.Add(userdb);
                _contex.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در ثبت اطلاعات رخ داده است. دوباره تلاش کنید.");
                Console.WriteLine(ex);
                return View(user);
            }
        }

        #endregion

        #region فراموشی رمز عبور

        [HttpGet]
        public IActionResult PasswordForgoten()
        {
            return View();
        }


        [HttpPost]
        public IActionResult PasswordForgoten(string Phone)
        {
            if (string.IsNullOrEmpty(Phone))
            {
                ModelState.AddModelError("", "لطفا شماره موبایل خود را وارد نمایید");
                return View();  
            }

            try
            {
                User user = _contex.Users.FirstOrDefault(x => x.Phone == Phone);
                if(user == null)
                {
                    ModelState.AddModelError("", "کاربری با این شماره موبایل موجود نیست");
                    return View();
                }

                return RedirectToAction("NewPassword", new { phone  = Phone });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در ثبت اطلاعات رخ داده است. دوباره تلاش کنید.");
                Console.WriteLine(ex);
                return View();
            }

        }


        #endregion

        #region  رمز عبور جدید

        [HttpGet]
        public IActionResult NewPassword(string phone)
        {
            ViewBag.phone = phone;  
            return View();
        }

        [HttpPost]
        public IActionResult NewPassword(string Phone ,string NewPass, string ReNewPass)
        {
            if (string.IsNullOrEmpty(NewPass) || string.IsNullOrEmpty(ReNewPass))
            {
                ModelState.AddModelError("", "لطفا تمامی فیلدهارا پر نمایید");
                return View();
            }

            if (NewPass != ReNewPass)
            {
                ModelState.AddModelError("", "رمز عبور و تکرار آن یکسان نیست");
                return View();
            }

            try
            {
                // پیدا کردن کاربر بر اساس شماره موبایل
                var user = _contex.Users.FirstOrDefault(u => u.Phone == Phone);
                if (user == null)
                {
                    ModelState.AddModelError("", "کاربری با این شماره یافت نشد.");
                    return View();
                }

                // آپدیت پسورد
                user.Password = NewPass;
                user.RePassword = ReNewPass; // اگر همچنان در مدل داری

                // EF Core به صورت خودکار تغییرات را ردیابی می‌کند
                _contex.SaveChanges(); // ← الزامی

                // بعد از موفقیت Redirect به Login
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطایی در ثبت اطلاعات رخ داده است. دوباره تلاش کنید.");
                Console.WriteLine(ex);
                return View();
            }
        }

        #endregion


    }
}

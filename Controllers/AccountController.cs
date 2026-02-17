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
        private readonly  IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        #region ورورد 

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Phone, string Pass)
        {
            User user = _userRepository.FindUserByPhone(Phone);
            if(user != null)
            {
                if (Pass == user.Password)
                    return RedirectToAction("");
                else
                    return View();

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
            {
                ViewBag.Error = "لطفا اطلاعات خود را درست وارد نمایید";
                return View();
            }

            User userdb = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Password = user.Password,
                TVType = user.TVType
            };

            _userRepository.InsertUser(userdb);
            _userRepository.Save();

            return View();
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
            return View();
        }
        #endregion
        //public IActionResult EmailAcceptance()
        //{
        //    return View();
        //}

        public IActionResult NewPassword()
        {
            return View();
        }



    }
}

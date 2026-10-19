using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;
using TvRepairWebsite.Models.ViewModels;

namespace TvRepairWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly TvRepairWebSiteDbContext _contex;
        public AdminController(TvRepairWebSiteDbContext cntx)
        {
            _contex = cntx;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Dashboard()
        {

            //بدست آوردن تعداد کاربران
            int UserCount =
                _contex
                .Users
                .Where(x => x.Admin == false)
                .Count();
            //تعداد محصولات
            int ProductCount = _contex.products.Count();
            //تعداد مقالات
            int ArticleCount = _contex.Articles.Count();

            AdminPanelVM adminPanel = new AdminPanelVM()
            {
                UserCount = UserCount,
                ProductCount = ProductCount,
                ArticleCount = ArticleCount
            };

            return PartialView("Partials/_Dashboard", adminPanel);
        }

        #region Product

        public IActionResult Products()
        {
            //لیست محصولات
            var products = _contex.products
                 .Include(p => p.Category)
                 .Include(p => p.Part)
                 .ToList();

            //لیست دسنه بندی محصولات
            var categories = _contex.CategoryProducts.ToList();
            //لیست قطعات
            var parts = _contex.partTypes.ToList();


            ProductAdminVM productAdminVM = new ProductAdminVM()
            {
                Products = products,
                Categories = categories,
                Parts = parts
            };

            return PartialView("Partials/_Products", productAdminVM);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductCreateVM model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "اطلاعات نامعتبر است" });

            string fileName = null;

            if (model.ImgUrl != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products");

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                fileName = Guid.NewGuid() + Path.GetExtension(model.ImgUrl.FileName);

                var filePath = Path.Combine(uploads, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                model.ImgUrl.CopyTo(stream);
            }

            var product = new Product
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                ImgUrl = fileName,
                CategoryId = model.CategoryId,
                PartId = model.PartId
            };

            _contex.products.Add(product);
            _contex.SaveChanges();

            return Json(new { success = true });
        }


        [HttpPost]
        public IActionResult EditProduct(ProductEditVM model)
        {
            if (model.ProductId == null)
                return Json(new { success = false });


            // اگر کاربر تصویر جدید نداد → هیچ تغییری در product.ImgUrl نمی‌دهد
            var product = _contex.products.Find(model.ProductId);

            if (product == null)
                return Json(new { success = false });

            product.Title = model.Title;
            product.Description = model.Description;
            product.Price = model.Price;
            product.DiscountPrice = model.DiscountPrice;
            product.CategoryId = model.CategoryId;
            product.PartId = model.PartId;

            if (model.ImgUrl != null && model.ImgUrl.Length > 0)
            {
                // ذخیره عکس جدید
                var fileName = Guid.NewGuid() + Path.GetExtension(model.ImgUrl.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.ImgUrl.CopyTo(stream);
                }

                product.ImgUrl = fileName;
            }

            _contex.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _contex.products.Find(id);

            if (product == null)
                return Json(new { success = false });

            _contex.products.Remove(product);
            _contex.SaveChanges();

            return Json(new { success = true });
        }

        #endregion

        #region Article

        public IActionResult Articles()
        {
            //گرفتن تمامی مقالات
            List<Article> articles = _contex.Articles.ToList();

            return PartialView("Partials/_Articles", articles);
        }
   
        [HttpPost]
        public async Task<IActionResult> ArticleCreate([FromForm] CreateArticleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("اطلاعات ارسالی ناقص است.");
            }

            try
            {
                string imgName = "default.png";

                // ۱. آپلود تصویر در مسیر wwwroot/images/articles
                if (dto.ImageFile != null && dto.ImageFile.Length > 0)
                {
                    imgName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ImageFile.FileName);
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, imgName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await dto.ImageFile.CopyToAsync(stream);
                    }
                }

                // ۲. ساخت آبجکت مقاله
                var article = new Article()
                {
                    Title = dto.Title,
                    Little_Description = dto.Little_Description,
                    Meta_Description = dto.Meta_Description,
                    ArticleAddress = string.IsNullOrWhiteSpace(dto.ArticleAddress)
                        ? dto.Title.Trim().Replace(" ", "-")
                        : dto.ArticleAddress.Trim().Replace(" ", "-"),
                    Introduction = dto.Introduction,
                    Body = dto.Body,
                    Conclusion = dto.Conclusion,
                    ImgUrl = imgName,
                    CreateDate = DateTime.Now,
                    ArticleQuestions = new List<ArticleQuestion>()
                };

                // ۳. استخراج سوالات متداول از JSON
                if (!string.IsNullOrEmpty(dto.FaqsJson))
                {
                    var faqs = JsonSerializer.Deserialize<List<FaqItemDto>>(dto.FaqsJson);
                    if (faqs != null)
                    {
                        foreach (var faq in faqs)
                        {
                            if (!string.IsNullOrWhiteSpace(faq.Question) && !string.IsNullOrWhiteSpace(faq.Answer))
                            {
                                article.ArticleQuestions.Add(new ArticleQuestion
                                {
                                    Question = faq.Question,
                                    Awnser = faq.Answer
                                    // فیلدهای دیگر مثل ArticleId توسط خود EF Core مقداردهی می‌شود
                                });
                            }
                        }
                    }
                }

                // ۴. ذخیره در دیتابیس
                _contex.Articles.Add(article);
                _contex.SaveChanges();

                return Json(new { success = true, message = "مقاله با موفقیت افزوده شد." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "خطای سیستمی رخ داده است.");
            }
        }

        [HttpPost]
        public IActionResult ArticleDelete(int id)
        {
            var article = _contex.Articles.Find(id);

            if (article == null)
                return NotFound();

            _contex.Articles.Remove(article);
            _contex.SaveChangesAsync();

            return Json(new { success = true });
        }

        #endregion

        #region User
        public IActionResult Users()
        {
            //لیست کاربران
            List<User> users = _contex.Users.ToList();

            return PartialView("Partials/_Users", users);
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserVM model)
        {
            if (model == null)
                return Json(new { success = false, message = "اطلاعات ارسال نشده است" });

            if (string.IsNullOrWhiteSpace(model.FirstName) ||
                string.IsNullOrWhiteSpace(model.LastName) ||
                string.IsNullOrWhiteSpace(model.Phone) ||
                string.IsNullOrWhiteSpace(model.Password))
            {
                return Json(new { success = false, message = "فیلدهای اجباری کامل نیستند" });
            }

            // بررسی تکراری بودن شماره موبایل
            bool phoneExists = _contex.Users
                .Any(u => u.Phone == model.Phone);

            if (phoneExists)
                return Json(new { success = false, message = "این شماره موبایل قبلاً ثبت شده است" });

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                TVType = model.TVType,
                Admin = model.Admin,

                // در پروژه واقعی باید Hash شود
                Password = model.Password,
                RePassword = model.Password
            };

            _contex.Users.Add(user);
            _contex.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult EditUser(User model)
        {
            if (model == null || model.UserId == null)
                return Json(new { success = false, message = "اطلاعات نامعتبر است" });

            var user = _contex.Users.Find(model.UserId);

            if (user == null)
                return Json(new { success = false, message = "کاربر یافت نشد" });

            // بررسی تکراری نبودن موبایل (به جز خودش)
            bool phoneExists = _contex.Users
                .Any(u => u.Phone == model.Phone && u.UserId != model.UserId);

            if (phoneExists)
                return Json(new { success = false, message = "این شماره موبایل قبلاً ثبت شده است" });

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Phone = model.Phone;
            user.TVType = model.TVType;
            user.Admin = model.Admin;
            if (user.Password != model.Password)
                user.Password = model.Password;
            _contex.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _contex.Users.Find(id);

            if (user == null)
                return Json(new { success = false, message = "کاربر یافت نشد" });

            _contex.Users.Remove(user);
            _contex.SaveChanges();

            return Json(new { success = true });
        }

        //[HttpPost]
        //public IActionResult SendSmsForUser()
        //{

        //}



        #endregion

        #region sms

        public IActionResult SmsPanel()
        {
            //List<SmsTemplate> smsTemplates = _contex.smsTemplates.ToList(); 


            return PartialView("Partials/_SmsPanel");
        }


        //[HttpPost]
        //public async Task<IActionResult> SaveSmsTemplate([FromBody] SmsTemplateDto model)
        //{
        //    if (model == null || string.IsNullOrWhiteSpace(model.Template))
        //        return Json(new { success = false, message = "متن نامعتبر است" });

        //    // مثال: ذخیره در دیتابیس
        //    var setting = await _context.Settings
        //        .FirstOrDefaultAsync(s => s.Key == "SmsTemplate");

        //    if (setting == null)
        //    {
        //        setting = new Setting
        //        {
        //            Key = "SmsTemplate",
        //            Value = model.Template
        //        };

        //        _context.Settings.Add(setting);
        //    }
        //    else
        //    {
        //        setting.Value = model.Template;
        //    }

        //    await _context.SaveChangesAsync();

        //    return Json(new { success = true });
        //}

        #endregion




    }
}

using Microsoft.EntityFrameworkCore;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;

namespace TvRepairWebsite.Services
{

    public interface IDiscountCodeService
    {
        string? CheckAndCreateDiscountAsync(int userId);
    }



    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly TvRepairWebSiteDbContext _context;

        public DiscountCodeService(TvRepairWebSiteDbContext dbContext)
        {
            _context = dbContext;
        }

        public string? CheckAndCreateDiscountAsync(int userId)
        {
            // ۱. بررسی اینکه آیا کاربر قبلاً کد تخفیف دریافت کرده یا خیر
            bool alreadyHasDiscount = _context.DicountCodes
                .Any(x => x.UserId == userId);

            if (alreadyHasDiscount)
            {
                return null; // قبلاً گرفته، تخفیف جدید داده نمی‌شود
            }

            // ۲. بررسی شرط اول: آیا حداقل ۲ مقاله را مشاهده کرده است؟
            // (بر اساس ساختار جدول لاگ بازدیدهای شما)
            int viewsCount =  _context.ArticleViews
                .Count(x => x.UserId == userId);

            if (viewsCount < 2)
            {
                return null; // شرط بازدید مقالات برقرار نیست
            }

            // ۳. بررسی شرط دوم: آیا حداقل ۱ نظر ثبت کرده است؟
            bool hasComment =  _context.Comments
                .Any(x => x. == userId);

            if (!hasComment)
            {
                return null; // شرط کامنت برقرار نیست
            }

            // ۴. کاربر واجد شرایط است؛ تولید یک کد تخفیف یکتا (مثلاً OFF-AB12)
            string generatedCode = "OFF-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            var discount = new DiscountCode
            {
                UserId = userId,
                Code = generatedCode,
                Percent = 20,              // درصد تخفیف دلخواه شما
                CreatedAt = DateTime.UtcNow,
                IsUsed = false,            // آیا خرج شده؟ خیر
                IsShown = true             // چون همین الان در Ajax پاپ‌آپ را باز می‌کنیم، تیک بخورد که بعداً دوباره لود نشود
            };

            // ۵. ذخیره در دیتابیس
            await _context.DiscountCodes.AddAsync(discount);
            await _context.SaveChangesAsync();

            // ۶. برگرداندن کد ساخته‌شده جهت ارسال به فرانت‌اند
            return generatedCode;
        }
    }
}

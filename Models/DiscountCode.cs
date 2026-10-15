using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class DiscountCode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string CreateDate  { get; set; } // تاریخ ایجاد کد تخفیف به شمسی و اعداد انگلیسی


        //Navigation Property
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

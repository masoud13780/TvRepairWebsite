using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string FullName { get; set; }
        [Display(Name = "ایمیل یا شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string EmailOrPhone { get; set; }
        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Subject {get; set; }
        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500)]
        public string Message { get; set; }

    }
}

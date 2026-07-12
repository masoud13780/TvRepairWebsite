using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models.ViewModels
{
    public class ContactUsVM
    {


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
        public string Subject { get; set; }
        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500)]
        public string Message { get; set; }
        public DateTime CraeteDate { get; set; }

    }
}

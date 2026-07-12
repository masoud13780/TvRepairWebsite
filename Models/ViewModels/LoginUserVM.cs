using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models.ViewModels
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name = "شماره همراه")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "فرمت شماره همراه درست نمی‌باشد")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name = "رمز عبور")]
        [MinLength(6, ErrorMessage = "رمز عبور از 6 کاراکتر نمی‌تواند کمتر باشد")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

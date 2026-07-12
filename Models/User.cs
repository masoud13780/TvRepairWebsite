using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvRepairWebsite.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public bool Admin { get; set; } = false;
        [Required(ErrorMessage ="لطفا {0} خود را وارد نمایید")]
        [Display(Name ="نام")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name = "نام خانوادگی")]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name ="شماره همراه")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="فرمت شماره همراه درست نمی‌باشد")]
        public string Phone { get; set; }
        //[Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        //[Display(Name = "شماره همراه")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "فرمت شماره همراه درست نمی‌باشد")]
        //public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name = "رمز عبور")]
        [MinLength(6,ErrorMessage ="رمز عبور از 6 کاراکتر نمی‌تواند کمتر باشد")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name = "تکرار رمز عبور")]
        [MinLength(6)]
        [MaxLength(20)]
        [Compare("Password",ErrorMessage ="تکرار رمز عبور با رمز عبور یکسان نیست")]
        [NotMapped]
        public string RePassword { get; set; }
        [Display(Name = "مدل تلویزیون")]
        [MaxLength(50)]
        public string? TVType { get; set; } = null;




        //public ICollection<Article> Articles { get; set; } = new List<Article>();

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvRepairWebsite.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "لطفا {0} خود را وارد نمایید")]
        [Display(Name = "شماره همراه")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "فرمت شماره همراه درست نمی‌باشد")]
        public string Phone { get; set; }
        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Display(Name = "تعداد ستاره")]
        [Range(1,5)]
        public int Rate { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }



    }
}

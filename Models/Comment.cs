using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvRepairWebsite.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public User UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
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

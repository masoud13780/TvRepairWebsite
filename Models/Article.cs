using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvRepairWebsite.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        //public int UserId { get; set; }
        [Display(Name ="عنوان")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }





    }
}

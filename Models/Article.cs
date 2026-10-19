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
        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Little_Description { get; set; }
        [Display(Name = "توضیحات متا")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Meta_Description { get; set; }
        public string ArticleAddress { get; set; }
        [Display(Name = "مقدمه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Introduction { get; set; }
        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Body { get; set; }
        [Display(Name = "جمع بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Conclusion { get; set; }
        public string ImgUrl { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }


        public List<ArticleQuestion> ArticleQuestions { get; set; }

    }
}

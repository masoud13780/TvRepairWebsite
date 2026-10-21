using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class ArticleQuestion
    {
        public int Id { get; set; }
        [Display(Name = "سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Question { get; set; }
        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Awnser { get; set; }


        //Navigation Property
        public Article  Article { get; set; }
        public int ArticleId { get; set; }
    }
}

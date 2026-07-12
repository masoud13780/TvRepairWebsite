using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvRepairWebsite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int? CategoryId { get; set; } = null;
        public int? PartId { get; set; } = null;
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Description { get; set; }
        //قیمت قدیم
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Price { get; set; }
        //قیمت جدید
        [Display(Name = "تخفیف")]
        public int DiscountPrice { get; set; }
        [Display(Name = "تصویر محصول")]
        public string ImgUrl { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public CategoryProduct Category { get; set; }
        [ForeignKey(nameof(PartId))]
        public PartType Part { get; set; }



    }
}

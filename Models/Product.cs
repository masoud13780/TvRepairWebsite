using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Price { get; set; }
        [Display(Name = "تخفیف")]
        public int DiscountPrice { get; set; }
        [Display(Name = "تصویر محصول")]
        public string ImgUrl { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models.ViewModels
{
    public class ProductEditVM
    {
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
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Price { get; set; }
        [Display(Name = "تخفیف")]
        public int DiscountPrice { get; set; }
        [Display(Name = "تصویر محصول")]
        public IFormFile ImgUrl { get; set; }
        public string ExistingImage { get; set; }
    }
}

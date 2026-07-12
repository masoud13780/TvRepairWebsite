using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class CategoryProduct
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "لطفا نام دسته بندی را وارد نمایید")]
        [MaxLength(50)]
        public string CategoryName { get; set; }


        public ICollection<Product> Products { get; set; }

    }
}

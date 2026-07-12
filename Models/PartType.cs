using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class PartType
    {
        [Key]
        public int PartId { get; set; }
        [Display(Name = "نام قطعه")]
        [Required(ErrorMessage = "لطفا نام قطعه را وارد نمایید")]
        [MaxLength(50)]
        public string PartName { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}

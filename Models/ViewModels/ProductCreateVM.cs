namespace TvRepairWebsite.Models.ViewModels
{
    public class ProductCreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }

        public int? CategoryId { get; set; } = null;
        public int? PartId { get; set; } = null;


        public IFormFile ImgUrl { get; set; }   // ← فقط برای آپلود
    }
}

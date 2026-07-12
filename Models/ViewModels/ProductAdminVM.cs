namespace TvRepairWebsite.Models.ViewModels
{
    public class ProductAdminVM
    {
        public List<Product> Products { get; set; }
        public List<CategoryProduct> Categories { get; set; }
        public List<PartType> Parts { get; set; }
    }
}

namespace TvRepairWebsite.Models.ViewModels
{
    public class CreateArticleDto
    {
        public string Title { get; set; } = null!;
        public string Little_Description { get; set; } = null!;
        public string Meta_Description { get; set; } = null!;
        public string ArticleAddress { get; set; } = null!;
        public string Introduction { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string Conclusion { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
        public string? FaqsJson { get; set; } // سوالات متداول به صورت رشته JSON
    }


    public class FaqItemDto
    {
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}

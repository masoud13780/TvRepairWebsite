namespace TvRepairWebsite.Models.ViewModels
{
    public class HomeVM
    {

        public User? user { get; set; }

        public CreateCommentVM CreateComment { get; set; }
        public List<Product> Products { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Article> Articles { get; set; }

    }
}

namespace TvRepairWebsite.Models.ViewModels
{
    public class ArticleViewVM
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TvRepairWebsite.Models
{
    public class ArticleView
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
    }
}

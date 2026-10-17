using TvRepairWebsite.Data;

namespace TvRepairWebsite.Repository
{

    public interface ICommentRepository
    {
        public bool ExistCommentForUser(int userId);
    }


    public class CommentRepository : ICommentRepository
    {
        private readonly TvRepairWebSiteDbContext _dbContext;

        public CommentRepository(TvRepairWebSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExistCommentForUser(int userId)
        {
            return _dbContext.Comments.Any(c => c.UserId == userId);
        }
    }
}

using TvRepairWebsite.Data;

namespace TvRepairWebsite.Repository
{

    public interface IDiscountCodeRepository
    {
        bool ExistCodeForUser(int userId);
    }


    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly TvRepairWebSiteDbContext _dbContext;
        public DiscountCodeRepository(TvRepairWebSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool ExistCodeForUser(int userId)
        {
            return _dbContext.DicountCodes.Any(x => x.UserId == userId);
        }
    }
}

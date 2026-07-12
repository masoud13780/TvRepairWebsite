using TvRepairWebsite.Data;
using TvRepairWebsite.Models;

namespace TvRepairWebsite.Repository
{
    public interface IArticleRepository
    {
        public List<Article> GetAllArticles();
        public Article GetArticle(int ArticleId);


    }



    public class ArticleRepository : IArticleRepository
    {
        private readonly TvRepairWebSiteDbContext _context;
        public ArticleRepository(TvRepairWebSiteDbContext context)
        {
            _context = context;
        }

        public List<Article> GetAllArticles()
        {
            try
            {

                return _context.Articles.ToList();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
        public Article GetArticle(int ArticleId)
        {
            try
            {
                return _context.Articles
                    .FirstOrDefault(a=> a.ArticleId == ArticleId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }




    }



}

using Microsoft.EntityFrameworkCore;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;

namespace TvRepairWebsite.Repository
{
    public interface IArticleRepository
    {
        public List<Article> GetAllArticles();
        public Article GetArticle(int ArticleId);


        public void InsertArticleView(ArticleView articleView);
        public bool ViewTwoArticle(int userId);
        public void Save(); 
    }



    public class ArticleRepository : IArticleRepository
    {
        private readonly TvRepairWebSiteDbContext _context;
        public ArticleRepository(TvRepairWebSiteDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Article> GetAllArticles()
        {
            try
            {

                return _context.Articles.ToList();

            }
            catch (Exception ex)
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
                    .Include(a => a.ArticleQuestions)
                    .FirstOrDefault(a => a.ArticleId == ArticleId)
                    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }



        public void InsertArticleView(ArticleView articleView)
        {
            try
            {
                var articleViewDb = _context.ArticleViews
                    .FirstOrDefault(a => a.UserId == articleView.UserId && a.ArticleId == articleView.ArticleId);
                if (articleViewDb != null)
                {
                    articleViewDb.ViewedAt = DateTime.Now;
                    _context.SaveChanges();
                    return;
                }

                _context.ArticleViews.Add(articleView);
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public bool ViewTwoArticle(int userId)
        {
            int Count = _context.ArticleViews.Count(a => a.UserId == userId);

            return Count >= 2;
        }



    }
}

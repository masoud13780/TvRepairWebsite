using Microsoft.EntityFrameworkCore;
using TvRepairWebsite.Data;
using TvRepairWebsite.Models;

namespace TvRepairWebsite.Repository
{
    public interface IProductRepository
    {

        public List<Product> GetAllProduct();


    }


    public class ProductRepository : IProductRepository
    {
        private readonly TvRepairWebSiteDbContext _context;
        public ProductRepository(TvRepairWebSiteDbContext context)
        {
            _context = context;
        }


        public List<Product> GetAllProduct()
        {
            try
            {

                return _context.products
                    .Include(p => p.Category)
                    .Include(p => p.Part)
                    .ToList();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }

        }


    }


}

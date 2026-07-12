using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvRepairWebsite.Data;
using TvRepairWebsite.Repository;

namespace TvRepairWebsite.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly TvRepairWebSiteDbContext _context;
        public StoreController(IProductRepository productRepository, TvRepairWebSiteDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public IActionResult Store(string brand, string part)
        {
            var products = _context.products
                .Include(p => p.Category)
                .Include(p => p.Part)
                .AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                products = products.Where(p => p.Category.CategoryName == brand);
            }

            if (!string.IsNullOrEmpty(part))
            {
                products = products.Where(p => p.Part.PartName == part);
            }

            return View(products.AsNoTracking().ToList());
        }




    }
}

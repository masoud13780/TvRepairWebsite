using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TvRepairWebsite.Models;


namespace TvRepairWebsite.Data
{
    public class TvRepairWebSiteDbContext : DbContext
    {
        public TvRepairWebSiteDbContext(DbContextOptions<TvRepairWebSiteDbContext> options)
            : base(options)
        {

        }


        //تعریف جدول کاربران
        public DbSet<User> Users { get; set; }
        //تعریف جدول نظرات
        public DbSet<Comment> Comments { get; set; }
        //تعریف جدول ارتباط بای ما
        public DbSet<ContactUs> contactUs { get; set; }
        //تعریف جدول مقاله
        public DbSet<Article> Articles { get; set; }    
        //تعریف جدول دسته بندی
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        //تعریف جدول قطعات
        public DbSet<PartType> partTypes { get; set; }
        //تعریف جدول محصولات
        public DbSet<Product> products { get; set; }
       //جدول
       public DbSet<SmsTemplate> smsTemplates { get; set; }
        public DbSet<ArticleView> ArticleViews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

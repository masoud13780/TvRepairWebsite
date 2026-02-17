using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TvRepairWebsite.Data;
using TvRepairWebsite.Repository;

var builder = WebApplication.CreateBuilder(args);

//Add DbContext
builder.Services.AddDbContext<TvRepairWebSiteDbContext>(Options =>
Options.UseSqlServer(
    builder.Configuration
    .GetConnectionString("DefaultConnection")
  )
);

//Add Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();



////Add Identity
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<TvRepairWebSiteDbContext>()
//    .AddDefaultTokenProviders();




// Add services to the container.
builder.Services.AddControllersWithViews();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

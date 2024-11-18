using LisbrarySystem.Models;
using LisbrarySystem.Repo.impelementation;
using LisbrarySystem.Repo.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LisbrarySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //custom services register
            builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Password.RequireNonAlphanumeric = false)
                .AddEntityFrameworkStores<Context>();

            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IBorrowRepo, BorrowRepo>();
            builder.Services.AddScoped<IBuyRepo,BuyRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=AllBooks}/{id?}");

            app.Run();
        }
    }
}

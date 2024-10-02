using System.IO;
using Cores.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Core.Entities;
using Web.Method_Helper;


namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            builder.Services.AddTransient<Methods>();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            var connectionString2 = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<DbAppContext>(options =>
                options.UseSqlServer(connectionString2));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddAuthorization(auth => auth.AddPolicy("AccessRole", p => p.RequireClaim("Admin", "Admin")));
            builder.Services.AddAuthorization(auth => auth.AddPolicy("AccessRoleUser", p => p.RequireClaim("User", "User")));

            builder.Services.AddIdentity<AppUsers, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI().
                AddDefaultTokenProviders();

            

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}

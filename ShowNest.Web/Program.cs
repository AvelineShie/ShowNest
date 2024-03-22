using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Logging;
using ShowNest.Web.Interfaces;
using ShowNest.Web.Services.General;
using ShowNest.Web.Services.Home;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Data;

namespace ShowNest.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 取得組態中資料庫連線設定
            string connectionString = builder.Configuration.GetConnectionString("DatabaseContext");
            //在DI Container註冊EF Core的DbContext
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

            // Registration Service
            builder.Services.AddScoped<OrderTicketService, OrderTicketService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<HomeCarouselService>();
            builder.Services.AddScoped<EventCardService>();
            builder.Services.AddScoped<CategoryTagService>();
            builder.Services.AddScoped<HomeService>();
            builder.Services.AddScoped<EventIndexService>();


            //// Facebook Data 測試中
            //builder.Services.AddAuthentication().AddFacebook(opt =>
            //{
            //    opt.ClientId = "";
            //    opt.ClientSecret = "";
            //});

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

            ///測試用路由
            //app.MapControllerRoute(
            //    name: "organizationEvents",
            //    pattern: "{OrganizationId}/{controller=Events}/{action=Index}/{EventId?}");
            ///以上測試中--------------------------------------------------------------------------------------------

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            
            app.Run();
        }
    }
}
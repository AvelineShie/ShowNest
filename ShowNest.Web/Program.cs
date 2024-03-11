using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Logging;
using ShowNest.Web.Data;
using ShowNest.Web.Interfaces;
using ShowNest.Web.Services.General;
using ShowNest.Web.Services.Home;

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
            builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<HomeCarouselService>();
            builder.Services.AddScoped<EventCardService>();
            builder.Services.AddScoped<CategoryTagService>();
            builder.Services.AddScoped<HomeService>();

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
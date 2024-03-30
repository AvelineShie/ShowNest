using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Logging;
using ShowNest.Web.Interfaces;
using ShowNest.Web.Services.General;
using ShowNest.Web.Services.Home;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Data;
using ShowNest.Web.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShowNest.Web.Services.Organization;
using ShowNest.Web.Services.Organizations;
using Microsoft.AspNetCore.Builder;

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
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            // Registration Service
            builder.Services.AddScoped<OrderTicketService, OrderTicketService>();
            builder.Services.AddScoped<HomeCarouselService>();
            builder.Services.AddScoped<EventCardService>();
            builder.Services.AddScoped<CategoryTagService>();
            builder.Services.AddScoped<HomeService>();
            builder.Services.AddScoped<EventIndexService>();
            builder.Services.AddScoped<EventDetailService>();
            builder.Services.AddScoped<OrganizationIndexService>();
            builder.Services.AddScoped<OrganizationDetailService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services
               .AddApplicationCoreServices()
               .AddWebServices();

            //// Facebook Data 測試中
            //builder.Services.AddAuthentication().AddFacebook(opt =>
            //{
            //    opt.ClientId = "";
            //    opt.ClientSecret = "";
            //});
            
            //登入餅乾
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

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
            //先驗證再授權
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseAuthorization();

            ///測試用路由
            //app.MapControllerRoute(
            //    name: "organizationEvents",
            //    pattern: "{OrganizationId}/{controller=Events}/{action=Index}/{EventId?}");
            ///以上測試中--------------------------------------------------------------------------------------------

            app.MapControllerRoute(
            name: "EventPages",//探索活動頁
            pattern: "Events/Explore/{page=1}",
            defaults: new { controller = "Events", action = "Index" });

            app.MapControllerRoute(
            name: "EventMainPages",//活動主頁面
            pattern: "Events/EventPage/OrganizationId={OrganizationId}&EventId={EventId}",
            defaults: new { controller = "Events", action = "EventPages" });

            app.MapControllerRoute(
            name: "OrganizationMainPages",//組織主頁面
            pattern: "Organizations/Index/OrganizationId={OrganizationId}/",
            defaults: new { controller = "Organizations", action = "Index" });

            app.MapControllerRoute(
            name: "NewEvent",
            pattern: "Dashboard/CreateEvent",
            defaults: new { controller = "Dashboard", action = "CreateEvent" });

            app.MapControllerRoute(
            name: "TicketSetting",
            pattern: "Dashboard/CreateEvent/SetTicket",
            defaults: new { controller = "Dashboard", Action = "SetTicket" }
            );

            app.MapControllerRoute(
            name: "TableSetting",
            pattern: "Dashboard/CreateEvent/SetTable",
            defaults: new { controller = "Dashboard", Action = "SetTable" }
            );

            app.MapControllerRoute(
            name: "EventSetting",
            pattern: "Dashboard/CreateEvent/SetEvent",
            defaults: new { controller = "Dashboard", Action = "SetEvent" }
            );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
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
using ShowNest.Web.Services.AccountService;
using ShowNest.Web.Services.Shared;
using ShowNest.Web.Services.Seats;
using Infrastructure.Services;
using ShowNest.Web.Services.Dashboard;
using ShowNest.Web.Services.TicketTypes;


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

            // Registration Repository
            // builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            builder.Services.AddScoped<ISeatAreaRepository, SeatAreaRepository>();
            builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            builder.Services.AddScoped<CategoryTagsRepository>();


            // Registration Service
            builder.Services.AddScoped<HomeCarouselService>();
            builder.Services.AddScoped<EventCardService>();
            builder.Services.AddScoped<CategoryTagService>();
            builder.Services.AddScoped<HomeService>();
            builder.Services.AddScoped<EventIndexService>();
            builder.Services.AddScoped<EventDetailService>();
            builder.Services.AddScoped<OrganizationIndexService>();
            builder.Services.AddScoped<OrganizationDetailService>();
            builder.Services.AddScoped<ISeatsService, SeatsService>();
            builder.Services.AddScoped<OverviewService>();
            builder.Services.AddScoped<OrgGeneralInfoService>();
            builder.Services.AddScoped<EventPageService>();
            builder.Services.AddScoped<SearchEventService>();

            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<CreateEventService>();
            
            builder.Services.AddScoped<EventsApiService>();
            builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();


            builder.Services.AddScoped<AccountService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<_LoggedInLayoutService>();
            
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
            //測試ECPay需要註解app.UseHttpsRedirection
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
            name: "SwitchExploreEventPages",//探索活動頁>切換活動頁籤
            pattern: "Events/Explore/{page=1}",
            defaults: new { controller = "Events", action = "Index" });

            //app.MapControllerRoute(
            //name: "SearchEventPages",//探索活動頁>搜尋功能
            //pattern: "Events/Search/{inputstring}",
            //defaults: new { controller = "Events", action = "Search" });

            app.MapControllerRoute(
            name: "EventMainPages",//活動主頁面
            pattern: "Events/EventPage/{EventId}",
            defaults: new { controller = "Events", action = "EventPage" });

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
            name: "DashboardOrganizationIdentifying", // 組織後台
            pattern: "Dashboard/Organizations/{id}/{ViewType?}",
            defaults: new { controller = "Dashboard", Action = "Organizations" }
            );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
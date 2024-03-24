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

            // ���o�պA����Ʈw�s�u�]�w
            string connectionString = builder.Configuration.GetConnectionString("DatabaseContext");
            //�bDI Container���UEF Core��DbContext
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


            //// Facebook Data ���դ�
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

            ///���եθ���
            //app.MapControllerRoute(
            //    name: "organizationEvents",
            //    pattern: "{OrganizationId}/{controller=Events}/{action=Index}/{EventId?}");
            ///�H�W���դ�--------------------------------------------------------------------------------------------

            app.MapControllerRoute(
                name: "eventPages",
                pattern: "Events/{page=1}",
        defaults: new { controller = "Events", action = "Index"});

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
            pattern: "Dashboard/CreateEvent/{SetEvent}",
            defaults: new { controller = "Dashboard", Action = "SetEvent" }
            );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
using Infrastructure.Services;
using ShowNest.Web.Services;
using ApplicationCore.Interfaces;
using ShowNest.Web.Helpers;

namespace ShowNest.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
           
            services.AddScoped<IUserAccountAPIService,UserAccountAPIService>();
            services.AddScoped<IEcpayOrderService, EcpayOrderService>();
            services.AddScoped<OrderTicketService>();
            services.AddScoped<EcpayHttpHelpers>();
            services.AddScoped<EventsIndexCardsAPIServiceByEf>();
            

            return services;
        }
    }
}

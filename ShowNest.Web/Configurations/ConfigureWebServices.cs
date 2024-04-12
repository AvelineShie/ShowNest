using Infrastructure.Services;
using ShowNest.Web.Services;
using ApplicationCore.Interfaces;

namespace ShowNest.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
           
            services.AddScoped<IUserAccountAPIService,UserAccountAPIService>();
            services.AddScoped<IEcpayOrderService, EcpayOrderService>();
            services.AddScoped<OrderTicketService>();
            services.AddScoped<EventsIndexCardsAPIServiceByEf>();
            

            return services;
        }
    }
}

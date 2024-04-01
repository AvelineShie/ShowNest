using Infrastructure.Services;

namespace ShowNest.Web.Configurations
{
    public static class ConfigureWerServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            //services.AddScoped<IMemberCenterViewModelService, MemberCenterViewModelService>();
            services.AddScoped<UserAccountAPIService>();
            services.AddScoped<OrderTicketService>();

            return services;
        }
    }
}

using Infrastructure.Services;

namespace ShowNest.Web.Configurations
{
    public static class ConfigureApplicationCoreServices
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderQueryService, OrderAPIService>();

            return services;
        }
    }
}

﻿using ApplicationCore.Interfaces;
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
            services.AddScoped<IEcpayOrderService, EcpayOrderService>();
            services.AddScoped<IEventCardQueryService, EventCardQueryServiceByEf>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IImgUploadService, CloudinaryService>();
            services.AddScoped<IEventOverviewService, EventOverviewService>();
            services.AddScoped<EventGeneralInfoApiService>();
            

            return services;
        }
    }
}

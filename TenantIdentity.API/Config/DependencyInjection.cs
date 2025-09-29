using TenantIdentity.Infrastructure.Startup;

namespace TenantIdentity.API.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterTenantModule(configuration)
                .RegisterAuthentication()
                .RegisterEventBus(configuration)
                .AddHealthChecks();

            return services;
        }
        private static IServiceCollection RegisterTenantModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories()
                .RegisterIdentityDBContext(configuration)
                .AddIdentityServices();


            return services;
        }
        private static IServiceCollection RegisterEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddEventBus(configuration);
            return services;
        }
        private static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy("CanDeletePolicy", policy =>
                policy.RequireClaim("Permissions", "CanDelete"));

            return services;
        }
    }
}

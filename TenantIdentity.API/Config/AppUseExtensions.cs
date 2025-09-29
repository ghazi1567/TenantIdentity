namespace TenantIdentity.API.Config
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder AppUse(this IApplicationBuilder app, IConfiguration configuration)
        {

            return app;
        }
    }
}

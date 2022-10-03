using WebApi.Middlewares;

namespace WebApi
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }

    }
}

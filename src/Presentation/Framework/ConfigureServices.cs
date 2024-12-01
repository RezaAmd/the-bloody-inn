using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheBloodyInn.Framework.Factories;
using TheBloodyInn.Infrastructure;

namespace TheBloodyInn.Framework
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddFrameworkServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);

            services.AddScoped<InnModelFactory>();

            return services;
        }
    }
}
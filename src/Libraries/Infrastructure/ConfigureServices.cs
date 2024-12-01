using Microsoft.Extensions.DependencyInjection;
using TheBloodyInn.Application.Common.Interfaces;

namespace TheBloodyInn.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAppDbContext, AppDbContext>()
            .AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

        return services;
    }
}
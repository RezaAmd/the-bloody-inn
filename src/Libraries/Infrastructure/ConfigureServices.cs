using Microsoft.Extensions.DependencyInjection;
using TheBloodyInn.Infrastructure.Repositories;
using TheBloodyInn.Infrastructure.Repositories.SQL.Users;

namespace TheBloodyInn.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IUserRepository, UserRepository>()
            ;
        return services;
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheBloodyInn.Application.Common.Interfaces;

namespace TheBloodyInn.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register SQL Server services.
        services.AddSqlServices(configuration);
        services
            .AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

        return services;
    }

    public static IServiceCollection AddSqlServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        if (string.IsNullOrEmpty(connectionString))
        {
            // TODO: Log here! (connectionstring was not found.)
            return services;
        }
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null))
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.None)));
        });

        services.AddScoped<IAppDbContext, AppDbContext>();

        return services;
    }
}
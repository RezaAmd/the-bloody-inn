using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TheBloodyInn.Application.Common.Behaviors;
using TheBloodyInn.Application.Common.Models;
using TheBloodyInn.Application.Common.Security.JwtBearer;
using TheBloodyInn.Application.Inns;
using TheBloodyInn.Application.Services.AssemblyServices;
using TheBloodyInn.Application.Services.Cards;
using TheBloodyInn.Application.Services.Identity;

namespace TheBloodyInn.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddFluentValidationServices();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>))
            .AddTransient<IJwtService, JwtService>()
            ;

        services.AddScoped<IIdentityService, IdentityService>()
            .AddScoped<ICardService, CardService>()
            ;

        services.AddScoped<InnService>();

        return services;
    }

    public static void ConfigureWritable<T>(
        this IServiceCollection services,
        IConfigurationSection section,
        string file = "appsettings.json") where T : class, new()
    {
        services.AddTransient<IAppSettingsService<T>>(provider =>
        {
            var configuration = (IConfigurationRoot)provider.GetService<IConfiguration>();
            var environment = provider.GetService<IWebHostEnvironment>();
            var options = provider.GetService<IOptionsMonitor<T>>();
            return new AppSettingsService<T>(environment, options, configuration, section.Key, file);
        });
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtSettingsDto? settings)
    {
        if (settings is null)
            return services;
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                var secretKey = Encoding.UTF8.GetBytes(settings.SecretKey);
                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = false,
                    ValidAudience = settings.Audience,

                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                };

                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = validationParameters;
            });
        return services;
    }

    private static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
    {
        // Automatic Validation.
        // https://github.com/FluentValidation/FluentValidation.AspNetCore#automatic-validation
        services.AddFluentValidationAutoValidation();

        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddFluentValidation(fv =>  // Fluent Validation
        {
            fv.RegisterValidatorsFromAssemblyContaining<BaseFluentValidator<object>>();
        });

        return services;
    }
}
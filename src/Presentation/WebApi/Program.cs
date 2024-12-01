using Microsoft.OpenApi.Models;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;
using TheBloodyInn.Application.Common.Models.DTOs.Settings;
using TheBloodyInn.Infrastructure;
using TheBloodyInn.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureWritable<AppSettingDto>(builder.Configuration.GetSection("SiteSettings"));
var appSetting = builder.Configuration.GetSection("SiteSettings").Get<AppSettingDto>();
if (appSetting is null)
    return;


ConfigureServices(builder.Services, appSetting);

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInUserCommand).Assembly));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region swagger authorization
var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};
var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};
var contact = new OpenApiContact()
{
    Name = "The Bloody Inn",
    Email = "support@thebloodyinn.games",
    Url = new Uri("https://thebloodyinn.games")
};
var license = new OpenApiLicense()
{
    Name = "Free License",
    Url = new Uri("https://thebloodyinn.games")
};
var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "The Bloody Inn SDK",
    Description = "Implementing JWT Authentication in SDK",
    TermsOfService = new Uri("https://thebloodyinn.games/terms"),
    Contact = contact,
    License = license
};

builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});
#endregion

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<GameHub>("/hub");

#region Endpoint
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Swagger}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=General}/{action=Index}/{id?}");
app.MapControllers();
#endregion

app.Run();

void ConfigureServices(IServiceCollection services, AppSettingDto appSetting)
{
    // Unit of work and repositories.
    services.AddInfrastructureServices();

    services.AddApplicationServices();
    // JWT Bearer.
    services.AddJwtAuthentication(appSetting.JwtSettings);
}
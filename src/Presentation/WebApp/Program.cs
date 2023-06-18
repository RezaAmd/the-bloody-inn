using TheBloodyInn.Application;
using TheBloodyInn.Infrastructure;
using TheBloodyInn.Application.Common.Models.DTOs.Settings;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureWritable<AppSettingDto>(builder.Configuration.GetSection("SiteSettings"));
var appSetting = builder.Configuration.GetSection("SiteSettings").Get<AppSettingDto>();
if (appSetting is null)
    return;

ConfigureServices(builder.Services, appSetting);

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInUserCommand).Assembly));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();


void ConfigureServices(IServiceCollection services, AppSettingDto appSetting)
{
    // Unit of work and repositories.
    services.AddInfrastructureServices();

    services.AddApplicationServices();
    // JWT Bearer.
    services.AddJwtAuthentication(appSetting.JwtSettings);
}
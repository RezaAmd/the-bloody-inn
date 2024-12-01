using Microsoft.AspNetCore.Authentication.Cookies;
using TheBloodyInn.Application;
using TheBloodyInn.Application.Common.Commands.Users.Authentication.SignIn;
using TheBloodyInn.Application.Common.Models.DTOs.Settings;
using TheBloodyInn.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Authentication & Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.AccessDeniedPath = "/forbidden";
        options.LoginPath = "/authentication/signin";
        builder.Configuration.Bind("CookieSettings", options);
    });
builder.Services.AddAuthorization();

builder.Services.ConfigureWritable<AppSettingDto>(builder.Configuration.GetSection("SiteSettings"));
//var appSetting = builder.Configuration.GetSection("SiteSettings").Get<AppSettingDto>();
//if (appSetting is null)
//    return;

// Unit of work and repositories.
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddApplicationServices();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInUserCommand).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
    OnPrepareResponse = (context) =>
    {
        var headers = context.Context.Response.GetTypedHeaders();
        headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromDays(100)
        };
    }
});

// Routing
app.UseRouting();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
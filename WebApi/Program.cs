using TheBloodyInn.Application.Common.Models.DTOs.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var appSetting = builder.Configuration.GetSection("SiteSettings").Get<AppSettingDto>();
if (appSetting is null)
    return;

builder.Services.AddJwtAuthentication(appSetting.JwtSettings);

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
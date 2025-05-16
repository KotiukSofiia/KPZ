using Microsoft.EntityFrameworkCore;
using QrCodeGenerator.Data;
using QrCodeGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration config)
{
    services.AddControllersWithViews();

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

    services.AddScoped<IQRService, QRService>();
    services.AddScoped<PdfService>();
    services.AddScoped<ZipService>();
    services.AddScoped<IQrContentFormatterService, QrContentFormatterService>();
    services.AddScoped<IHistoryQueryService, HistoryQueryService>();
}

void ConfigureMiddleware(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}

using Microsoft.EntityFrameworkCore;
using QrCodeGenerator.Commands;
using QrCodeGenerator.Data;
using QrCodeGenerator.Models;
using QrCodeGenerator.Services;
using QrCodeGenerator.Services.Formatting;

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

    // Сервіси форматування QR-контенту (Strategy)
    services.AddScoped<IQrContentStrategy, EmailStrategy>();
    services.AddScoped<IQrContentStrategy, SmsStrategy>();
    services.AddScoped<IQrContentStrategy, WifiStrategy>();
    services.AddScoped<IQrContentStrategy, DefaultStrategy>();
    services.AddScoped<IQrContentFormatterService, QrContentFormatterService>();

    services.AddScoped<IHistoryQueryService, HistoryQueryService>();

    services.AddScoped<IQrCodeMediator, QrCodeMediator>();

    services.AddScoped<IRepository, QrCodeRepository>();
    services.AddScoped<ICommand<(QrInputModel, string), CommandResult>, GenerateQrCodeCommand>();
    services.AddScoped<ICommand<QrInputModel, CommandResult>, PreviewQrCodeCommand>();
    services.AddScoped<ICommand<string, CommandResult>, DownloadPdfCommand>();
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
using Microsoft.AspNetCore.Mvc;
using QrCodeGenerator.Data;
using QrCodeGenerator.Models;
using QrCodeGenerator.Services;

namespace QrCodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQRService _qrService;
        private readonly PdfService _pdfService;
        private readonly AppDbContext _db;
        private readonly IQrContentFormatterService _formatter;

        public HomeController(IQRService qrService, PdfService pdfService, AppDbContext db, IQrContentFormatterService formatter)
        {
            _qrService = qrService;
            _pdfService = pdfService;
            _db = db;
            _formatter = formatter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Generate(QrInputModel input, string format = "png")
        {
            if (!ModelState.IsValid)
                return View("Index", input);

            string content = _formatter.Format(input);

            if (string.IsNullOrWhiteSpace(content))
                return RedirectToAction("Index");

            string imagePath = _qrService.GenerateQrCode(
                content,
                format,
                input.ForegroundColor,
                input.BackgroundColor,
                input.Size
            );

            var record = new QrCodeRecord
            {
                InputText = content,
                ImagePath = imagePath,
                Format = format,
                Type = input.QrType,
                GeneratedAt = DateTime.UtcNow
            };

            _db.QrCodes.Add(record);
            _db.SaveChanges();

            ViewBag.QrPath = imagePath;
            ViewBag.InputText = content;

            return View("Index");
        }

        [HttpPost]
        public IActionResult Preview(QrInputModel input, string format = "png")
        {
            string content = _formatter.Format(input);

            if (string.IsNullOrWhiteSpace(content))
                return BadRequest();

            var imageStream = _qrService.GenerateQrImageStream(
                content,
                format,
                input.ForegroundColor,
                input.BackgroundColor,
                input.Size
            );

            return File(imageStream, $"image/{format}");
        }

        [HttpPost]
        public IActionResult DownloadPdf(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return RedirectToAction("Index");

            var pdfBytes = _pdfService.GeneratePdfWithImage(imagePath);
            return File(pdfBytes, "application/pdf", "QRCode.pdf");
        }
    }
}

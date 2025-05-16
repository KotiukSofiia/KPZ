using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Hosting;

namespace QrCodeGenerator.Services
{
    public class PdfService
    {
        private readonly IWebHostEnvironment _env;

        public PdfService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public byte[] GeneratePdfWithImage(string imagePath)
        {
            var fullPath = Path.Combine(_env.WebRootPath, imagePath.TrimStart('/'));

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf);

            var imgData = iText.IO.Image.ImageDataFactory.Create(fullPath);
            var image = new Image(imgData);

            document.Add(image);
            document.Close();

            return ms.ToArray();
        }
    }
}

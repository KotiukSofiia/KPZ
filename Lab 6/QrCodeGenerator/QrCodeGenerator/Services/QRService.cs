using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace QrCodeGenerator.Services
{
    public class QRService : IQRService
    {
        private readonly IWebHostEnvironment _env;

        public QRService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string GenerateQrCode(string text, string format = "png", string foregroundColor = "#000000", string backgroundColor = "#ffffff", int size = 300)
        {
            var bitmap = GenerateQrBitmap(text, foregroundColor, backgroundColor, size);

            string fileName = $"qr_{DateTime.Now.Ticks}.{format}";
            string relativePath = Path.Combine("images", fileName);
            string fullPath = Path.Combine(_env.WebRootPath, relativePath);

            EnsureDirectoryExists(fullPath);

            bitmap.Save(fullPath, GetImageFormat(format));

            return $"/{relativePath.Replace("\\", "/")}";
        }

        public MemoryStream GenerateQrImageStream(string text, string format = "png", string foregroundColor = "#000000", string backgroundColor = "#ffffff", int size = 300)
        {
            var bitmap = GenerateQrBitmap(text, foregroundColor, backgroundColor, size);
            var stream = new MemoryStream();
            bitmap.Save(stream, GetImageFormat(format));
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private Bitmap GenerateQrBitmap(string text, string fgColor, string bgColor, int size)
        {
            var generator = new QRCodeGenerator();
            var data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCode(data);
            using var rawBitmap = qrCode.GetGraphic(20, ParseColor(fgColor), ParseColor(bgColor), true);
            return new Bitmap(rawBitmap, new Size(size, size));
        }

        private static Color ParseColor(string htmlColor)
        {
            try
            {
                return ColorTranslator.FromHtml(htmlColor);
            }
            catch
            {
                return Color.Black;
            }
        }

        private static ImageFormat GetImageFormat(string format) =>
            format.ToLower() == "bmp" ? ImageFormat.Bmp : ImageFormat.Png;

        private void EnsureDirectoryExists(string fullPath)
        {
            var dir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir!);
        }
    }
}

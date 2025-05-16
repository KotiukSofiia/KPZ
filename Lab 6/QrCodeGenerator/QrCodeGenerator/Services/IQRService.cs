using System.IO;

namespace QrCodeGenerator.Services
{
    public interface IQRService
    {
        string GenerateQrCode(string text, string format = "png", string foregroundColor = "#000000", string backgroundColor = "#ffffff", int size = 300);
        MemoryStream GenerateQrImageStream(string text, string format = "png", string foregroundColor = "#000000", string backgroundColor = "#ffffff", int size = 300);
    }
}

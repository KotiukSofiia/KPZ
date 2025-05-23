using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services.Formatting
{
    public interface IQrContentStrategy
    {
        bool CanHandle(QrInputModel model);
        string Format(QrInputModel model);
    }
}
using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services.Formatting
{
    public class DefaultStrategy : IQrContentStrategy
    {
        public bool CanHandle(QrInputModel model) => true;

        public string Format(QrInputModel model) => model.Text ?? "";
    }
}

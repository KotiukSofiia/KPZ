using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services
{
  public interface IQrCodeMediator
  {
    CommandResult GenerateAndStoreQrCode(QrInputModel input, string format);
  }
}

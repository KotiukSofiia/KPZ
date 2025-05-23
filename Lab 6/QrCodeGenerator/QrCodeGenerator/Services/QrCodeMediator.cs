using QrCodeGenerator.Models;
using System.ComponentModel.DataAnnotations;

namespace QrCodeGenerator.Services
{
  
  public class QrCodeMediator : IQrCodeMediator
  {
    private readonly IQRService _qrService;
    private readonly IQrContentFormatterService _formatter;
    private readonly IRepository _repository;

    public QrCodeMediator(
        IQRService qrService,
        IQrContentFormatterService formatter,
        IRepository repository)
    {
      _qrService = qrService;
      _formatter = formatter;
      _repository = repository;
    }

    public CommandResult GenerateAndStoreQrCode(QrInputModel input, string format)
    {
      
      var validationResults = new List<ValidationResult>();
      bool isValid = Validator.TryValidateObject(input, new ValidationContext(input), validationResults, true);
      if (!isValid)
      {
        return CommandResult.Fail(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
      }

      // Генерація QR-коду
      string content = _formatter.Format(input);
      string imagePath = _qrService.GenerateQrCode(content, format, input.ForegroundColor, input.BackgroundColor, input.Size);

      // Збереження
      var record = new QrCodeRecord
      {
        InputText = content,
        ImagePath = imagePath,
        Format = format,
        Type = input.QrType,
        GeneratedAt = DateTime.UtcNow
      };
      _repository.AddQrCodeRecord(record);
      _repository.SaveChanges();

      return CommandResult.Ok(new { QrPath = imagePath, InputText = content });
    }
  }
}

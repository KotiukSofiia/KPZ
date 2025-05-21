using QrCodeGenerator.Models;
using QrCodeGenerator.Services;
using System.ComponentModel.DataAnnotations;

namespace QrCodeGenerator.Commands
{
    public class GenerateQrCodeCommand : ICommand<(QrInputModel input, string format), CommandResult>
    {
        private readonly IQRService _qrService;
        private readonly IQrContentFormatterService _formatter;
        private readonly IRepository _repository;

        public GenerateQrCodeCommand(
            IQRService qrService,
            IQrContentFormatterService formatter,
            IRepository repository)
        {
            _qrService = qrService;
            _formatter = formatter;
            _repository = repository;
        }

        public CommandResult Execute((QrInputModel input, string format) parameters)
        {
            var (input, format) = parameters;

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(input, new ValidationContext(input), validationResults, true);

            if (!isValid)
            {
                var errorMessages = validationResults.Select(vr => vr.ErrorMessage);
                return CommandResult.Fail(string.Join("; ", errorMessages));
            }

            string content = _formatter.Format(input);

            if (string.IsNullOrWhiteSpace(content))
            {
                return CommandResult.Fail("Content is empty");
            }

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

            _repository.AddQrCodeRecord(record);
            _repository.SaveChanges();

            return CommandResult.Ok(new { QrPath = imagePath, InputText = content });
        }
    }
}
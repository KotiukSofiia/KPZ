using QrCodeGenerator.Models;
using QrCodeGenerator.Services;

namespace QrCodeGenerator.Commands
{
    public class PreviewQrCodeCommand : ICommand<QrInputModel, CommandResult>
    {
        private readonly IQRService _qrService;
        private readonly IQrContentFormatterService _formatter;

        public PreviewQrCodeCommand(
            IQRService qrService,
            IQrContentFormatterService formatter)
        {
            _qrService = qrService;
            _formatter = formatter;
        }

        public CommandResult Execute(QrInputModel input)
        {
            string content = _formatter.Format(input);

            if (string.IsNullOrWhiteSpace(content))
            {
                return CommandResult.Fail("Content is empty");
            }

            var imageStream = _qrService.GenerateQrImageStream(
                content,
                "png",
                input.ForegroundColor,
                input.BackgroundColor,
                input.Size
            );

            return CommandResult.Ok(imageStream);
        }
    }
}
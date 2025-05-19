using QrCodeGenerator.Models;
using QrCodeGenerator.Services;

namespace QrCodeGenerator.Commands
{
    public class DownloadPdfCommand : ICommand<string, CommandResult>
    {
        private readonly PdfService _pdfService;
        private readonly IWebHostEnvironment _env;

        public DownloadPdfCommand(PdfService pdfService, IWebHostEnvironment env)
        {
            _pdfService = pdfService;
            _env = env;
        }

        public CommandResult Execute(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return CommandResult.Fail("Image path is empty");
            }

            var fullPath = Path.Combine(_env.WebRootPath, imagePath.TrimStart('/'));

            if (!File.Exists(fullPath))
            {
                return CommandResult.Fail("File not found");
            }

            var pdfBytes = _pdfService.GeneratePdfWithImage(imagePath);
            return CommandResult.Ok(pdfBytes);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using QrCodeGenerator.Data;
using QrCodeGenerator.Models;
using QrCodeGenerator.Services;

namespace QrCodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommand<(QrInputModel, string), CommandResult> _generateCommand;
        private readonly ICommand<QrInputModel, CommandResult> _previewCommand;
        private readonly ICommand<string, CommandResult> _downloadCommand;

        public HomeController(
            ICommand<(QrInputModel, string), CommandResult> generateCommand,
            ICommand<QrInputModel, CommandResult> previewCommand,
            ICommand<string, CommandResult> downloadCommand)
        {
            _generateCommand = generateCommand;
            _previewCommand = previewCommand;
            _downloadCommand = downloadCommand;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Generate(QrInputModel input, string format = "png")
        {
            var result = _generateCommand.Execute((input, format));

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View("Index", input);
            }

            var data = (dynamic)result.Data;
            ViewBag.QrPath = data.QrPath;
            ViewBag.InputText = data.InputText;

            return View("Index", input);
        }

        [HttpPost]
        public IActionResult Preview(QrInputModel input)
        {
            var result = _previewCommand.Execute(input);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return File((MemoryStream)result.Data, "image/png");
        }

        [HttpPost]
        public IActionResult DownloadPdf(string imagePath)
        {
            var result = _downloadCommand.Execute(imagePath);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return File((byte[])result.Data, "application/pdf", "QRCode.pdf");
        }
    }
}

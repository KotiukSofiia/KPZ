using Microsoft.AspNetCore.Mvc;
using QrCodeGenerator.Models.ViewModels;
using QrCodeGenerator.Services;

namespace QrCodeGenerator.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryQueryService _historyService;

        public HistoryController(IHistoryQueryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IActionResult Index(string? type, string? sort)
        {
            var records = _historyService.GetFiltered(
                type,
                sort,
                out var types,
                out var selectedType,
                out var selectedSort
            );

            var viewModel = new HistoryViewModel
            {
                Records = records,
                AvailableTypes = types,
                SelectedType = selectedType,
                SelectedSort = selectedSort
            };

            return View(viewModel);
        }
    }
}

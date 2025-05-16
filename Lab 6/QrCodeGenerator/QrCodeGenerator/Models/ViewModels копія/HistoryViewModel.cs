namespace QrCodeGenerator.Models.ViewModels
{
    using QrCodeGenerator.Models;
    using System.Collections.Generic;

    public class HistoryViewModel
    {
        public List<QrCodeRecord> Records { get; set; } = new();
        public List<string> AvailableTypes { get; set; } = new();
        public string SelectedType { get; set; } = "";
        public string SelectedSort { get; set; } = "date";
    }
}

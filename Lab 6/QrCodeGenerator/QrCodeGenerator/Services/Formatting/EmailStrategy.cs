using QrCodeGenerator.Models;
using System.Text.RegularExpressions;

namespace QrCodeGenerator.Services.Formatting
{
    public class EmailStrategy : IQrContentStrategy
    {
        public bool CanHandle(QrInputModel model) =>
            model.QrType == "Email" && IsValidEmail(model.EmailTo);

        public string Format(QrInputModel model) =>
            $"mailto:{model.EmailTo}?subject={Uri.EscapeDataString(model.Subject ?? "")}" +
            $"&body={Uri.EscapeDataString(model.Body ?? "")}";

        private bool IsValidEmail(string? email) =>
            !string.IsNullOrWhiteSpace(email) &&
            Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}
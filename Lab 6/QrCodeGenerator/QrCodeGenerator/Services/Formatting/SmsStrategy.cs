using QrCodeGenerator.Models;
using System.Text.RegularExpressions;

namespace QrCodeGenerator.Services.Formatting
{
    public class SmsStrategy : IQrContentStrategy
    {
        public bool CanHandle(QrInputModel model) =>
            model.QrType == "SMS" && IsValidPhone(model.PhoneNumber);

        public string Format(QrInputModel model) =>
            $"SMSTO:{model.PhoneNumber}:{model.SmsMessage ?? ""}";

        private bool IsValidPhone(string? phone) =>
            !string.IsNullOrWhiteSpace(phone) &&
            Regex.IsMatch(phone, @"^\+?\d{10,}$");
    }
}
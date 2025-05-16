using QrCodeGenerator.Models;
using System.Text.RegularExpressions;

namespace QrCodeGenerator.Services
{
    public interface IQrContentFormatterService
    {
        string Format(QrInputModel model);
    }

    public class QrContentFormatterService : IQrContentFormatterService
    {
        public string Format(QrInputModel model)
        {
            return model.QrType switch
            {
                "Email" when IsValidEmail(model.EmailTo) =>
                    $"mailto:{model.EmailTo}?subject={Uri.EscapeDataString(model.Subject ?? "")}&body={Uri.EscapeDataString(model.Body ?? "")}",

                "SMS" when IsValidPhone(model.PhoneNumber) =>
                    $"SMSTO:{model.PhoneNumber}:{model.SmsMessage ?? ""}",

                "WiFi" when !string.IsNullOrWhiteSpace(model.WifiSSID) =>
                    $"WIFI:T:{(model.WifiEncryption ?? "WPA")};S:{model.WifiSSID};P:{model.WifiPassword ?? ""};;",

                _ => model.Text ?? ""
            };
        }

        private bool IsValidEmail(string? email) =>
            !string.IsNullOrWhiteSpace(email) &&
            Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private bool IsValidPhone(string? phone) =>
            !string.IsNullOrWhiteSpace(phone) &&
            Regex.IsMatch(phone, @"^\+?\d{10,}$");
    }
}

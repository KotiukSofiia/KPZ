using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services.Formatting
{
    public class WifiStrategy : IQrContentStrategy
    {
        public bool CanHandle(QrInputModel model) =>
            model.QrType == "WiFi" && !string.IsNullOrWhiteSpace(model.WifiSSID);

        public string Format(QrInputModel model) =>
            $"WIFI:T:{(model.WifiEncryption ?? "WPA")};" +
            $"S:{model.WifiSSID};P:{model.WifiPassword ?? ""};;";
    }
}
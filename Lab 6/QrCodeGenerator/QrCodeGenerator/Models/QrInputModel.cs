using System.ComponentModel.DataAnnotations;

public class QrInputModel
{
    [Required(ErrorMessage = "Оберіть тип QR-коду")]
    public string QrType { get; set; }

    public string? Text { get; set; }

    [EmailAddress(ErrorMessage = "Некоректний Email")]
    public string? EmailTo { get; set; }

    public string? Subject { get; set; }
    public string? Body { get; set; }

    [Phone(ErrorMessage = "Некоректний номер телефону")]
    public string? PhoneNumber { get; set; }

    public string? SmsMessage { get; set; }

    public string? WifiSSID { get; set; }
    public string? WifiPassword { get; set; }

    public string WifiEncryption { get; set; } = "WPA";

    public string ForegroundColor { get; set; } = "#000000";
    public string BackgroundColor { get; set; } = "#ffffff";

    [Range(100, 1000, ErrorMessage = "Розмір має бути від 100 до 1000")]
    public int Size { get; set; } = 300;
}
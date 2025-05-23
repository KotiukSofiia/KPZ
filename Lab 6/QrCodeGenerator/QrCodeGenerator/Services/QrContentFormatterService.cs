using QrCodeGenerator.Models;
using QrCodeGenerator.Services.Formatting;
using System.Text.RegularExpressions;

namespace QrCodeGenerator.Services
{
    public interface IQrContentFormatterService
    {
        string Format(QrInputModel model);
    }

    public class QrContentFormatterService : IQrContentFormatterService
    {
        private readonly IEnumerable<IQrContentStrategy> _strategies;

        public QrContentFormatterService(IEnumerable<IQrContentStrategy> strategies)
        {
            _strategies = strategies;
        }

        public string Format(QrInputModel model)
        {
            var strategy = _strategies.FirstOrDefault(s => s.CanHandle(model));
            return strategy?.Format(model) ?? string.Empty;
        }
    }
}
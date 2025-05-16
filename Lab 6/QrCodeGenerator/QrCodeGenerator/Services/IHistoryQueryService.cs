using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services
{
    public interface IHistoryQueryService
    {
        List<QrCodeRecord> GetFiltered(
            string? type,
            string? sort,
            out List<string> types,
            out string selectedType,
            out string selectedSort);
    }
}

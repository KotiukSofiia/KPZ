using QrCodeGenerator.Data;
using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services
{
    public class HistoryQueryService : IHistoryQueryService
    {
        private readonly AppDbContext _db;

        public HistoryQueryService(AppDbContext db)
        {
            _db = db;
        }

        public List<QrCodeRecord> GetFiltered(
            string? type,
            string? sort,
            out List<string> types,
            out string selectedType,
            out string selectedSort)
        {
            var query = _db.QrCodes.AsQueryable();

            types = _db.QrCodes.Select(q => q.Type).Distinct().OrderBy(t => t).ToList();

            selectedType = type ?? "";
            selectedSort = sort ?? "date";

            if (!string.IsNullOrWhiteSpace(type))
                query = query.Where(q => q.Type == type);

            query = selectedSort switch
            {
                "format" => query.OrderByDescending(q => q.Format),
                "text" => query.OrderByDescending(q => q.InputText),
                _ => query.OrderByDescending(q => q.GeneratedAt)

            };

            return query.ToList();
        }
    }
}

using QrCodeGenerator.Data;
using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services
{
    public class QrCodeRepository : IRepository
    {
        private readonly AppDbContext _db;

        public QrCodeRepository(AppDbContext db)
        {
            _db = db;
        }

        public void AddQrCodeRecord(QrCodeRecord record)
        {
            _db.QrCodes.Add(record);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}

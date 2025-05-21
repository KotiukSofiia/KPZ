using QrCodeGenerator.Models;

namespace QrCodeGenerator.Services
{
    public interface IRepository
    {
        void AddQrCodeRecord(QrCodeRecord record);
        void SaveChanges();
    }
}

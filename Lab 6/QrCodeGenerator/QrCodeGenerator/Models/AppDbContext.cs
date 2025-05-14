using Microsoft.EntityFrameworkCore;
using QrCodeGenerator.Models;

namespace QrCodeGenerator.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<QrCodeRecord> QrCodes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}

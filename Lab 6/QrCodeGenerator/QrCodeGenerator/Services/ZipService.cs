using System.IO.Compression;
using Microsoft.AspNetCore.Hosting;

namespace QrCodeGenerator.Services
{
    public class ZipService
    {
        private readonly IWebHostEnvironment _env;

        public ZipService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public byte[] CreateZipFromPaths(List<string> relativePaths)
        {
            using var ms = new MemoryStream();
            using var archive = new ZipArchive(ms, ZipArchiveMode.Create, true);

            foreach (var relativePath in relativePaths)
            {
                var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/'));
                if (!File.Exists(fullPath)) continue;

                var entryName = Path.GetFileName(fullPath);
                var entry = archive.CreateEntry(entryName, CompressionLevel.Fastest);

                using var input = File.OpenRead(fullPath);
                using var output = entry.Open();
                input.CopyTo(output);
            }

            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace QrCodeGenerator.Models
{
    public class QrCodeRecord
    {
        public int Id { get; set; }

        [Required]
        public string InputText { get; set; } = null!;

        [Required]
        public string ImagePath { get; set; } = null!;

        public string Format { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}

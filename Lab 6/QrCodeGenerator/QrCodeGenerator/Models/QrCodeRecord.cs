using System;
using System.ComponentModel.DataAnnotations;

namespace QrCodeGenerator.Models
{
    public class QrCodeRecord
    {
        public int Id { get; set; }
        public string InputText { get; set; }
        public string ImagePath { get; set; }
        public string Format { get; set; }
        public DateTime GeneratedAt { get; set; }
    }

}

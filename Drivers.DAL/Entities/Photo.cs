using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL_ADO.Entities
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public byte[]? PhotoData { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
        public int? FileSize { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

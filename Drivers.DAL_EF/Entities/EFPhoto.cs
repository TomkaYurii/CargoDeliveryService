using System;
using System.Collections.Generic;

namespace Drivers.DAL_EF.Entities
{
    public partial class EFPhoto
    {
        public int PhotoId { get; set; }
        public byte[] PhotoData { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public int FileSize { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual EFDriver? Driver { get; set; }
    }
}

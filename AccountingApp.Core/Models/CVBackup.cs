using System;

namespace Perfactcv.Core.Models
{
    public class CVBackup
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Data { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid UserId { get; set; }
    }
}

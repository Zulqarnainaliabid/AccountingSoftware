using System;

namespace Perfactcv.Api.Resources
{
    public class CVBackupResource
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Data { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
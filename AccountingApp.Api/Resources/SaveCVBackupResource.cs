using System;

namespace Perfactcv.Api.Resources
{
    public class SaveCVBackupResource
    {
        public string Subject { get; set; }
        public string Data { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
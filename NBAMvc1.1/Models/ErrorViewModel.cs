using System;

namespace NBAMvc1._1.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Message { get; set; }

        public int? Code { get; set; }

        public string Path { get; set; }
    }
}
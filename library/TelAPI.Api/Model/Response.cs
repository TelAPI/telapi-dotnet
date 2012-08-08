using System;

namespace TelAPI
{
    public class Response : TelAPIBase
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}

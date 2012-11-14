using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class ApplicationResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "applications")]
        public List<Application> Applications { get; set; }
    }
}

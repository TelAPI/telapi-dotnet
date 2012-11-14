using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class CallResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "calls")]
        public List<Call> Calls { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace TelAPI
{
    public class Capabilites
    {
        [JsonProperty(PropertyName = "voice")]
        public bool Voice { get; set; }

        [JsonProperty(PropertyName = "sms")]
        public bool Sms { get; set; }
    }
}

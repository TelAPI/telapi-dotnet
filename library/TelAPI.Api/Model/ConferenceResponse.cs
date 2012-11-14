using Newtonsoft.Json;
using System;

namespace TelAPI
{
    public class ConferenceResponse : TelAPIBase
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}

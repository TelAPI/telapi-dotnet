using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class ConferenceResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "conferences")]
        public List<Conference> Conferences { get; set; }
    }
}

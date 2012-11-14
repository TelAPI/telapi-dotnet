using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class RecordingResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "recordings")]
        public List<Recording> Recordings { get; set; }
    }
}

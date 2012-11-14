using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class TranscriptionResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "transcriptions")]
        public List<Transcription> Transcriptions { get; set; }
    }
}

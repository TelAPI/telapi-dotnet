using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class ParticipantResult
    {
        [JsonProperty(PropertyName = "participants")]
        public List<Participant> Participants { get; set; }
    }
}

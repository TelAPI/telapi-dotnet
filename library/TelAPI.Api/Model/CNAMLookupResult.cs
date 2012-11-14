using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class CNAMDipResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "cnam_dips")]
        public List<CNAMDip> CNAMDips { get; set; }
    }
}

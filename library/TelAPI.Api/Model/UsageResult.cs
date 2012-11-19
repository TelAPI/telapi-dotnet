using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelAPI
{
    public class UsageResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "usages")]
        public List<Usage> Usages { get; set; }
    }
}

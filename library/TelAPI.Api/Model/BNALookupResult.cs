using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelAPI
{
    public class BNALookupResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "bna_lookups")]
        public List<BNALookup> BNALookups { get; set; }
    }
}

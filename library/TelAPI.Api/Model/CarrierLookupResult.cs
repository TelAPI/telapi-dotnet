using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class CarrierLookupResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "carrier_lookups")]
        public List<CarrierLookup> CarrierLookups { get; set; }
    }
}

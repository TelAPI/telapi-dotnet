using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class FraudResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "frauds")]
        public Fraud Frauds { get; set; }
    }
}

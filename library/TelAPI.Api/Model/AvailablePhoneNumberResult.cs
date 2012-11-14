using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class AvailablePhoneNumberResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "available_phone_numbers")]
        public List<AvailablePhoneNumber> AvailablePhoneNumbers { get; set; }
    }
}

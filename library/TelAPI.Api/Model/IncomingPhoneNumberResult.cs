using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelAPI
{
    public class IncomingPhoneNumberResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "incoming_phone_numbers")]
        public List<IncomingPhoneNumber> IncomingPhoneNumbers { get; set; }
    }
}

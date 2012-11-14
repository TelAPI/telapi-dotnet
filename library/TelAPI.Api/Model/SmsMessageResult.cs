using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class SmsMessageResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "sms_messages")]
        public List<SmsMessage> SmsMessages { get; set; }
    }
}

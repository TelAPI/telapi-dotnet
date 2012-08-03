using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class SmsMessageResult : TelAPIListBase
    {
        public List<SmsMessage> SmsMessages { get; set; }
    }
}

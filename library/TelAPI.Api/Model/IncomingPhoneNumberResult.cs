using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class IncomingPhoneNumberResult : TelAPIListBase
    {
        public List<IncomingPhoneNumber> IncomingPhoneNumbers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class AvailablePhoneNumberResult : TelAPIListBase
    {
        public List<AvailablePhoneNumber> AvailablePhoneNumbers { get; set; }
    }
}

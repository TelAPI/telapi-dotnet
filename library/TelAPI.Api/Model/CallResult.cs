using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class CallResult : TelAPIListBase
    {
        public List<Call> Calls { get; set; }
    }
}

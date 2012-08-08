using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class FraudResult : TelAPIListBase
    {
        public List<Fraud> Frauds { get; set; }
    }
}

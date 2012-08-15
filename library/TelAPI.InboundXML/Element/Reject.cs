using System;
using System.Collections.Generic;
using YAXLib;

using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Reject")]
    public class Reject : ELement
    {
        [YAXAttributeForClass]
        [YAXSerializeAs("reason")]
        public string Reason { get; set; }

        public Reject()
        {

        }

        public static Reject Create(RejectReason? reason)
        {
            var reject = new Reject();            
            reject.Reason = reason == null ? null : reason.ToString();

            return reject;
        }
    }
}

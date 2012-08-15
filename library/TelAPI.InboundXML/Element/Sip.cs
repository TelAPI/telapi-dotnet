using System;
using System.Collections.Generic;
using YAXLib;

using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Sip")]
    public class Sip : DialElement
    {
        [YAXValueForClass]
        public string SipAddress { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("sendDigits")]
        public string SendDigits { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("url")]
        public string Url { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("method")]
        public string Method { get; set; }

        public Sip()
        {

        }

        public static Sip Create(string sipAddress, string sendDigits, string url, HttpMethod? method)
        {
            Sip sip = new Sip();

            sip.SipAddress = sipAddress;
            sip.SendDigits = sendDigits;
            sip.Url = url;
            sip.Method = method == null ? null : method.ToString();

            return sip;
        }
    }
}

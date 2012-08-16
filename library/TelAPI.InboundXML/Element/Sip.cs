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

        /// <summary>
        /// The Sip element is nested within the Dial element, and is used to call to sip addresses.
        /// </summary>
        /// <param name="sipAddress">Sip address</param>
        /// <param name="sendDigits">Specifies which DTFM tones to play to the called party. w indicates a half second pause.</param>
        /// <param name="url">URL that the called party can be directed to before the call beings.</param>
        /// <param name="method">method used to request the url.</param>
        /// <returns></returns>
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

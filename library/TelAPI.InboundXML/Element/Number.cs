using System;
using System.Collections.Generic;
using YAXLib;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Number")]
    public class Number : DialElement
    {

        [YAXValueForClass]
        public string Value { get; set;}

        [YAXAttributeForClass]
        [YAXSerializeAs("sendDigits")]
        public string SendDigits { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("url")]
        public string Url { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("method")]
        public string Method { get; set; }

        public Number()
        {

        }

        /// <summary>
        /// It can be used to send DTFM tones or redirect to InboundXML
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="sendDigits">Specifies which DTFM tones to play to the called party. w indicates a half second pause.</param>
        /// <param name="url">URL that the called party can be directed to before the call beings.</param>
        /// <param name="method">method used to request the url.</param>
        /// <returns></returns>
        public static Number Create(string number, string sendDigits, string url, HttpMethod? method)
        {
            var num = new Number();

            num.Value = number;
            num.SendDigits = sendDigits;
            num.Url = url;
            num.Method = method == null ? null : method.ToString();

            return num;
        }
    }
}

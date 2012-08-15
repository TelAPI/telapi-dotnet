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

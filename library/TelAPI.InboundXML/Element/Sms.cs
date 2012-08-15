using System;
using System.Collections.Generic;
using YAXLib;

using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Sms")]
    public class Sms : ELement
    {
        [YAXValueForClass]
        public string Text { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("to")]
        public string To { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("from")]
        public string From { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("action")]
        public string Action { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("method")]
        public string Method { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("statusCallback")]
        public string StatusCallback { get; set; }

        public Sms()
        {

        }

        public static Sms Create(string text, string to, string from, string action, HttpMethod? method, string statusCallback)
        {
            Sms sms = new Sms();

            sms.Text = text;
            sms.To = to;
            sms.From = from;
            sms.Action = action;
            sms.Method = method == null ? null : method.ToString();
            sms.StatusCallback = statusCallback;

            return sms;
        }
    }       
}

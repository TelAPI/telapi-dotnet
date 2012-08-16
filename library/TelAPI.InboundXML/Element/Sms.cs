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

        /// <summary>
        /// The <Sms> element can be used to send SMS messages.
        /// </summary>
        /// <param name="text">Body of message</param>
        /// <param name="to">The phone number that will receive the SMS message.</param>
        /// <param name="from">The number that will display as sending the SMS message.</param>
        /// <param name="action">URL where paramaters specific to Sms are sent.</param>
        /// <param name="method">Method used to request the action URL.</param>
        /// <param name="statusCallback">URL where the status of the SMS can be sent.</param>
        /// <returns></returns>
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

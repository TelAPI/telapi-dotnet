using System;
using System.Collections.Generic;

namespace TelAPI
{
    /// <summary>
    /// Text messages sent to and from TelAPI phone numbers are represented with the Sms resource.
    /// </summary>
    public class SmsMessage : TelAPIBase
    {
        /// <summary>
        /// The Api Version being used when the SMS was sent or received.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// An alphanumeric string used for identification of sms messages.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this sms occurred through.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// The date the SMS resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the SMS resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Date the SMS was sent.
        /// </summary>
        public DateTime DateSent { get; set; }

        /// <summary>
        /// The number that received the SMS message.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The number that sent the SMS message.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Text of the SMS message sent or received. May be up to 160 characters in length.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Status of the SMS: sent, sending, queued, or failed.
        /// </summary>
        public SmsMessageStatus Status { get; set; }

        /// <summary>
        /// Specifies the direction of the SMS: messages from REST API are "outbound-api", messages from incoming phone numbers to TelAPI are "incoming", messages from InboundXML initiated during an outbound call are "outbound-call", and messages from InboundXML initiated via an sms reply are "outbound-reply".
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Cost of the SMS.
        /// </summary>
        public Decimal Price { get; set; }

        /// <summary>
        /// The path appended to the base TelAPI URL, https://api.telapi.com, where the resource is located.
        /// </summary>
        public string Url { get; set; }
    }
}

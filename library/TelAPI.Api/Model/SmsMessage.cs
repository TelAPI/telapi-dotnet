using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// An alphanumeric string used for identification of sms messages.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this sms occurred through.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// The date the SMS resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the SMS resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Date the SMS was sent.
        /// </summary>
        [JsonProperty(PropertyName = "date_sent")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateSent { get; set; }

        /// <summary>
        /// The number that received the SMS message.
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }

        /// <summary>
        /// The number that sent the SMS message.
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        /// <summary>
        /// Text of the SMS message sent or received. May be up to 160 characters in length.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Status of the SMS: sent, sending, queued, or failed.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public SmsMessageStatus Status { get; set; }

        /// <summary>
        /// Specifies the direction of the SMS: messages from REST API are "outbound-api", messages from incoming phone numbers to TelAPI are "incoming", messages from InboundXML initiated during an outbound call are "outbound-call", and messages from InboundXML initiated via an sms reply are "outbound-reply".
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        /// <summary>
        /// Cost of the SMS.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public Decimal Price { get; set; }

    }
}

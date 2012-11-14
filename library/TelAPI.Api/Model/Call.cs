using System;
using Newtonsoft.Json;

namespace TelAPI
{
    /// <summary>
    /// A call resource provides information about an individual call that has occurred through TelAPI.
    /// </summary>
    public class Call : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used for identification of calls.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// The date the call resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the call resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// If the call was created during a different call using InboundXML, this is the sid of that initiating call.
        /// </summary>
        [JsonProperty(PropertyName = "parent_call_sid")]
        public string ParentCallSid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this call occurred through.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// The number that was called.
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }
        
        /// <summary>
        /// The number that initiated the call.
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }
        
        /// <summary>
        /// The sid of the TelAPI number calling, or being called. If no TelAPI phone number is involved in the call, this property is empty.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number_sid")]
        public string PhoneNumberSid { get; set; }

        /// <summary>
        /// The status of the call: queued, ringing, in-progress, completed, failed, busy, no-answer.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        
        /// <summary>
        /// The date the call started.
        /// </summary>
        [JsonProperty(PropertyName = "start_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? StartTime { get; set; }
        
        /// <summary>
        /// The date the call ended.
        /// </summary>
        [JsonProperty(PropertyName = "end_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The length of the call in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }
        
        /// <summary>
        /// The cost of the call, if availible.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The direction of the call from the perspective of TelAPI. Inbound for calls to TelAPI, outbound-api for calls from the TelAPI via REST request or outbound-dial for calls from TelAPI via InboundXML.
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }
        
        /// <summary>
        /// If the initiated call has answering machine detection, this specifies whether the machine answered. Can be human or machine.
        /// </summary>
        [JsonProperty(PropertyName = "answered_by")]
        public string AnsweredBy { get; set; }

        /// <summary>
        /// The Api Version being used when the call was initiated or received.
        /// </summary>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }
        
        /// <summary>
        /// The number that forwared the call, if any.
        /// </summary>
        [JsonProperty(PropertyName = "forwarded_from")]
        public string ForwardedFrom { get; set; }
        
        /// <summary>
        /// Specifies whether the caller ID of the inbound phone number was blocked.
        /// </summary>
        [JsonProperty(PropertyName = "caller_name")]
        public string CallerName { get; set; }

        /// <summary>
        /// Sip privacy
        /// </summary>
        [JsonProperty(PropertyName = "sip_privacy")]
        public string SipPrivacy { get; set; }

        /// <summary>
        /// Privacy hide number
        /// </summary>
        [JsonProperty(PropertyName = "privacy_hide_number")]
        public bool PrivacyHideNumber { get; set; }
    }
}

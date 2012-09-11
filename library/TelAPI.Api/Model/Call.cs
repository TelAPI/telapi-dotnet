using System;

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
        public string Sid { get; set; }

        /// <summary>
        /// The date the call resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the call resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// If the call was created during a different call using InboundXML, this is the sid of that initiating call.
        /// </summary>
        public string ParentCallSid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this call occurred through.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// The number that was called.
        /// </summary>
        public string To { get; set; }
        
        /// <summary>
        /// The number that initiated the call.
        /// </summary>
        public string From { get; set; }
        
        /// <summary>
        /// The sid of the TelAPI number calling, or being called. If no TelAPI phone number is involved in the call, this property is empty.
        /// </summary>
        public string PhoneNumberSid { get; set; }

        /// <summary>
        /// The status of the call: queued, ringing, in-progress, completed, failed, busy, no-answer.
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// The date the call started.
        /// </summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// The date the call ended.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The length of the call in seconds.
        /// </summary>
        public string Duration { get; set; }
        
        /// <summary>
        /// The cost of the call, if availible.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The direction of the call from the perspective of TelAPI. Inbound for calls to TelAPI, outbound-api for calls from the TelAPI via REST request or outbound-dial for calls from TelAPI via InboundXML.
        /// </summary>
        public string Direction { get; set; }
        
        /// <summary>
        /// If the initiated call has answering machine detection, this specifies whether the machine answered. Can be human or machine.
        /// </summary>
        public string AnsweredBy { get; set; }

        /// <summary>
        /// The Api Version being used when the call was initiated or received.
        /// </summary>
        public string ApiVersion { get; set; }
        
        /// <summary>
        /// The number that forwared the call, if any.
        /// </summary>
        public string ForwardedFrom { get; set; }
        
        /// <summary>
        /// Specifies whether the caller ID of the inbound phone number was blocked.
        /// </summary>
        public string CallerName { get; set; }

        /// <summary>
        /// Sip privacy
        /// </summary>
        public string SipPrivacy { get; set; }

        /// <summary>
        /// Privacy hide number
        /// </summary>
        public bool PrivacyHideNumber { get; set; }
    }
}

using System;

namespace TelAPI
{
    public class IncomingPhoneNumber : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used for identification of incoming phone numbers.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this phone number is registered with.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// Domestic format version of the TelAPI phone number  
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The E.164 format number of each incoming number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The type of TelAPI number. (local, international, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Voice application sid
        /// </summary>
        public string VoiceApplicationSid { get; set; }

        /// <summary>
        /// The URL returning InboundXML incoming calls should execute when connected.
        /// </summary>
        public string VoiceUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the VoiceUrl once incoming call connects.
        /// </summary>
        public string VoiceMethod { get; set; }

        /// <summary>
        /// URL used if any errors occur during execution of InboundXML on a call or at initial request of the VoiceUrl.
        /// </summary>
        public string VoiceFallbackUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the VoiceFallBackUrl if it is needed.
        /// </summary>
        public string VoiceFallbackMethod { get; set; }

        /// <summary>
        /// Look up the callers caller-ID name from the CNAM database (additional charges apply). Either true or false.
        /// </summary>
        public bool VoiceCallerIdLookup { get; set; }

        /// <summary>
        /// The date the incoming phone number resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the incoming phone number resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Sms application sid
        /// </summary>
        public string SmsApplicationSid { get; set; }
        
        /// <summary>
        /// The URL returning InboundXML incoming phone numbers should execute when receiving an sms.
        /// </summary>
        public string SmsUrl { get; set; }

        /// <summary>
        /// The HTTP method TelApi will use when making requests to the SmsUrl. Either GET or POST.
        /// </summary>
        public string SmsMethod { get; set; }

        /// <summary>
        /// URL used if any errors occur during execution of InboundXML from an sms or at initial request of the SmsUrl.
        /// </summary>
        public string SmsFallbackUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the SmsFallbackUrl.
        /// </summary>
        public string SmsFallbackMethod { get; set; }

        /// <summary>
        /// URL that can be used to monitor the phone number.
        /// </summary>
        public string HeartbeatUrl { get; set; }

        /// <summary>
        /// The HTTP method TelApi will use when requesting the HeartbeatURL. Either GET or POST.
        /// </summary>
        public string HeartbeatMethod { get; set; }

        /// <summary>
        /// The features available with this incoming phone number. The Elements voice and sms are nested within this property with their values as either True or False depending on what the number is capable of.
        /// </summary>
        public Capabilites Capabilities { get; set; }

        /// <summary>
        /// URL that can be requested to receive notification when and how incoming call has ended.
        /// </summary>
        public string HangupCallback { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the HangupCallback URL.
        /// </summary>
        public string HangupCallbackMethod { get; set; }

        /// <summary>
        /// The API version used with this incoming phone number.
        /// </summary>
        public string ApiVersion { get; set; }
    }
}

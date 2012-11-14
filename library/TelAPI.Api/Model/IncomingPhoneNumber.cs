using Newtonsoft.Json;
using System;

namespace TelAPI
{
    public class IncomingPhoneNumber : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used for identification of incoming phone numbers.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this phone number is registered with.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// Domestic format version of the TelAPI phone number  
        /// </summary>
        [JsonProperty(PropertyName = "friendly_name")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The E.164 format number of each incoming number.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The type of TelAPI number. (local, international, etc.)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Voice application sid
        /// </summary>
        [JsonProperty(PropertyName = "voice_application_sid")]
        public string VoiceApplicationSid { get; set; }

        /// <summary>
        /// The URL returning InboundXML incoming calls should execute when connected.
        /// </summary>
        [JsonProperty(PropertyName = "voice_url")]
        public string VoiceUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the VoiceUrl once incoming call connects.
        /// </summary>
        [JsonProperty(PropertyName = "voice_method")]
        public string VoiceMethod { get; set; }

        /// <summary>
        /// URL used if any errors occur during execution of InboundXML on a call or at initial request of the VoiceUrl.
        /// </summary>
        [JsonProperty(PropertyName = "voice_fallback_url")]
        public string VoiceFallbackUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the VoiceFallBackUrl if it is needed.
        /// </summary>
        [JsonProperty(PropertyName = "voice_fallback_method")]
        public string VoiceFallbackMethod { get; set; }

        /// <summary>
        /// Look up the callers caller-ID name from the CNAM database (additional charges apply). Either true or false.
        /// </summary>
        [JsonProperty(PropertyName = "voice_caller_id_lookup")]
        public bool VoiceCallerIdLookup { get; set; }

        /// <summary>
        /// The date the incoming phone number resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the incoming phone number resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Sms application sid
        /// </summary>
        [JsonProperty(PropertyName = "sms_application_sid")]
        public string SmsApplicationSid { get; set; }
        
        /// <summary>
        /// The URL returning InboundXML incoming phone numbers should execute when receiving an sms.
        /// </summary>
        [JsonProperty(PropertyName = "sms_url")]
        public string SmsUrl { get; set; }

        /// <summary>
        /// The HTTP method TelApi will use when making requests to the SmsUrl. Either GET or POST.
        /// </summary>
        [JsonProperty(PropertyName = "sms_method")]
        public string SmsMethod { get; set; }

        /// <summary>
        /// URL used if any errors occur during execution of InboundXML from an sms or at initial request of the SmsUrl.
        /// </summary>
        [JsonProperty(PropertyName = "sms_fallback_url")]
        public string SmsFallbackUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the SmsFallbackUrl.
        /// </summary>
        [JsonProperty(PropertyName = "sms_fallback_method")]
        public string SmsFallbackMethod { get; set; }

        /// <summary>
        /// URL that can be used to monitor the phone number.
        /// </summary>
        [JsonProperty(PropertyName = "heartbeat_url")]
        public string HeartbeatUrl { get; set; }

        /// <summary>
        /// The HTTP method TelApi will use when requesting the HeartbeatURL. Either GET or POST.
        /// </summary>
        [JsonProperty(PropertyName = "heartbeat_method")]
        public string HeartbeatMethod { get; set; }

        /// <summary>
        /// The features available with this incoming phone number. The Elements voice and sms are nested within this property with their values as either True or False depending on what the number is capable of.
        /// </summary>
        [JsonProperty(PropertyName = "capabilites")]
        public Capabilites Capabilities { get; set; }

        /// <summary>
        /// URL that can be requested to receive notification when and how incoming call has ended.
        /// </summary>
        [JsonProperty(PropertyName = "hangup_callback")]
        public string HangupCallback { get; set; }

        /// <summary>
        /// Specifies the HTTP method (GET or POST) used to request the HangupCallback URL.
        /// </summary>
        [JsonProperty(PropertyName = "hangup_callback_method")]
        public string HangupCallbackMethod { get; set; }

        /// <summary>
        /// The API version used with this incoming phone number.
        /// </summary>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }
    }
}

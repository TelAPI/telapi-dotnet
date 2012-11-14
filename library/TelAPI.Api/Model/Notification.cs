using Newtonsoft.Json;
using System;

namespace TelAPI
{
    public class Notification : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used to identify the notification.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string used for identification of the account which this notification resource belongs.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// An alphanumeric string used for identification of the call that the notification occurred during. Since notifications don't have to necessarily occur during calls, this property could be empty.
        /// </summary>
        [JsonProperty(PropertyName = "call_sid")]
        public string CallSid { get; set; }

        /// <summary>
        /// The API version being used when notification occurred. Could be empty if no api version used when the notification occurred.
        /// </summary>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// The date the notification resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the notification resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Specifies the notification log level: 2=INFO, 1=WARNING, 0=ERROR.
        /// </summary>
        [JsonProperty(PropertyName = "log")]
        public int Log { get; set; }

        /// <summary>
        /// Identifies the specific error type. For more information on error codes see the Error Dictionary.
        /// </summary>
        [JsonProperty(PropertyName = "error_code")]
        public long ErrorCode { get; set; }

        /// <summary>
        /// URL leading to our error dictionary for more information on the error.
        /// </summary>
        [JsonProperty(PropertyName = "more_info")]
        public string MoreInfo { get; set; }

        /// <summary>
        /// Text of the notification message.
        /// </summary>
        [JsonProperty(PropertyName = "message_text")]
        public string MessageText { get; set; }

        /// <summary>
        /// The date the TelAPI account received the actual notification. May be a bit different from DateCreated due to buffering.
        /// </summary>
        [JsonProperty(PropertyName = "message_date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime MessageDate { get; set; }

        /// <summary>
        /// The HTTP body returned by your server when the notification occurred.
        /// </summary>
        [JsonProperty(PropertyName = "response_body")]
        public string ResponseBody { get; set; }

        /// <summary>
        /// The URL being requested when notification was generated.
        /// </summary>
        [JsonProperty(PropertyName = "request_url")]
        public string RequestUrl { get; set; }

        /// <summary>
        /// The method used to request RequestUrl when the notification was generated.
        /// </summary>
        [JsonProperty(PropertyName = "request_method")]
        public string RequestMethod { get; set; }

        /// <summary>
        /// The variables sent with the HTTP request that generated the notification.
        /// </summary>
        [JsonProperty(PropertyName = "request_variables")]
        public string RequestVariables { get; set; }

        /// <summary>
        /// HTTP headers returned by your server when the notification occurred.
        /// </summary>
        [JsonProperty(PropertyName = "response_headers")]
        public string ResponseHeaders { get; set; }
       
    }
}

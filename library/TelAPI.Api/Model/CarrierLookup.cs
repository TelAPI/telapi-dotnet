using System;
using Newtonsoft.Json;

namespace TelAPI
{
    public class CarrierLookup : TelAPIBase
    {
        /// <summary>
        /// The Api Version being used when the CNAM look up was made.
        /// </summary>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// An alphanumeric string used for identification of the CNAM look up resource.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this look up occurred through.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// Date the CNAM look up resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date the CNAM look up resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The phone number the look up was performed on.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The carrier of the phone number we are looking up.
        /// </summary>
        [JsonProperty(PropertyName = "carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Cost of the look up.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Specifies if the phone number is mobile. can be true or false.
        /// </summary>
        [JsonProperty(PropertyName = "is_mobile")]
        public bool IsMobile { get; set; }

        /// <summary>
        /// Code used to identify the phone numbers geographic origin. Found at the beginning of the number.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Carrier Identification Code. A four digit code used to route and switch calls.
        /// </summary>
        [JsonProperty(PropertyName = "cic_code")]
        public string CICCode { get; set; }
        
    }
}

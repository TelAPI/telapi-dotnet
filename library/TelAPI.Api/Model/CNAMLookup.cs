using System;
using Newtonsoft.Json;

namespace TelAPI
{
    public class CNAMDip : TelAPIBase
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
        /// The result of our CNAM look up. Usually a name or organization associated with this phone.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Cost of the look up.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelAPI
{
    public class Fraud : TelAPIBase
    {
        /// <summary>
        /// The price limit an outbound call may be. Calls which cost more will be rejected.
        /// </summary>
        [JsonProperty(PropertyName = "max_outbound_rate")]
        public decimal MaxOutboundRate { get; set; }

        [JsonProperty(PropertyName = "destinations")]
        public Destinations Destinations { get; set; }
    }

    public class Destinations
    {
        [JsonProperty(PropertyName = "blocked")]
        public List<Country> Blocked { get; set; }

        [JsonProperty(PropertyName = "authorized")]
        public List<Country> Authorized { get; set; }

        [JsonProperty(PropertyName = "whitelisted")]
        public List<Country> Whitelisted { get; set; }
    }

    public class Country
    {
        /// <summary>
        /// Full name of the destination being whitelisted, authorized or blocked.
        /// </summary>
        [JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }

        /// <summary>
        /// Two letter country code being whitelisted, authorized or blocked.
        /// </summary>
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Prefix of the destination being whitelisted, authorized or blocked.
        /// </summary>
        [JsonProperty(PropertyName = "country_prefix")]
        public string CountryPrefix { get; set; }

        /// <summary>
        /// Mobile breakout status of the destination. Can be true or false.
        /// </summary>
        [JsonProperty(PropertyName = "mobile_breakout")]
        public bool MobileBreakout { get; set; }

        /// <summary>
        /// Landline breakout status of the destination. Can be true or false.
        /// </summary>
        [JsonProperty(PropertyName = "landline_breakout")]
        public bool LandlineBreakout { get; set; }

        /// <summary>
        /// Status of the SMS for destination. Can be true or false. If false, SMS for same destination will be rejected.
        /// </summary>
        [JsonProperty(PropertyName = "sms_enabled")]
        public bool SmsEnabled { get; set; }

        /// <summary>
        /// The date the fraud control resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the fraud control resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The date the fraud control resource will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiration_date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpirationDate { get; set; }
    }
}

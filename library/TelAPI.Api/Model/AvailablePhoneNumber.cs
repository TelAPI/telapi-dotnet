using System;
using Newtonsoft.Json;

namespace TelAPI
{
    public class AvailablePhoneNumber : TelAPIBase
    {
        /// <summary>
        /// Domestic format version of the available phone number
        /// </summary>
        [JsonProperty(PropertyName = "friendly_name")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The E.164 format number of each available number
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Local Access and Transportation Area of the available number. The LATA is determined by geographical region.
        /// </summary>
        [JsonProperty(PropertyName = "lata")]
        public string Lata { get; set; }

        /// <summary>
        /// The available phone numbers rate center.
        /// </summary>
        [JsonProperty(PropertyName = "rate_center")]
        public string RateCenter { get; set; }

        /// <summary>
        /// The latitude of the available phone number.
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// The longitude of the available phone number.
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// Code used to identify the phone numbers geographic origin. Found at the beginning of the number.
        /// </summary>
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Numbering Plan Area of the available number. This is more commonly known as the area code.
        /// </summary>
        [JsonProperty(PropertyName = "npa")]
        public string NPA { get; set; }

        /// <summary>
        /// Three digits following the NPA (area code) in the available number.
        /// </summary>
        [JsonProperty(PropertyName = "exchange")]
        public string Exchange { get; set; }

        /// <summary>
        /// The available phone numbers city.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// The region of the available phone number. Usually a two letter abbreviation.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        /// <summary>
        /// The postal code (also known as zip code) of the available number.
        /// </summary>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Two letter country code of the available phone number.
        /// </summary>
        [JsonProperty(PropertyName = "iso_country")]
        public string IsoCountry { get; set; }

        /// <summary>
        /// Type of phone number. (e.g. local, international, etc.)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Cost of phone number setup.
        /// </summary>
        [JsonProperty(PropertyName = "setup_cost")]
        public decimal SetupCost { get; set; }

        /// <summary>
        /// Cost of phone number per month.
        /// </summary>
        [JsonProperty(PropertyName = "monthly_cost")]
        public decimal MonthlyCost { get; set; }

        /// <summary>
        /// Unblock support
        /// </summary>
        [JsonProperty(PropertyName = "unblock_support")]
        public bool UnblockSupport { get; set; }

        /// <summary>
        /// Is Voice enabled for this phone number
        /// </summary>
        [JsonProperty(PropertyName = "voice_enabled")]
        public bool VoiceEnabled { get; set; }

        /// <summary>
        /// Is SMS enabled for this phone number
        /// </summary>
        [JsonProperty(PropertyName = "sms_enabled")]
        public bool SmsEnabled { get; set; }

        /// <summary>
        /// Does phone number support forwarded from
        /// </summary>
        [JsonProperty(PropertyName = "supports_forwarded_from")]
        public bool SupportsForwardedFrom { get; set; }
    }
}

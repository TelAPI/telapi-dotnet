using System;

namespace TelAPI
{
    public class AvailablePhoneNumber : TelAPIBase
    {
        /// <summary>
        /// Domestic format version of the available phone number
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The E.164 format number of each available number
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Local Access and Transportation Area of the available number. The LATA is determined by geographical region.
        /// </summary>
        public string Lata { get; set; }

        /// <summary>
        /// The available phone numbers rate center.
        /// </summary>
        public string RateCenter { get; set; }

        /// <summary>
        /// The latitude of the available phone number.
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// The longitude of the available phone number.
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// Code used to identify the phone numbers geographic origin. Found at the beginning of the number.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Numbering Plan Area of the available number. This is more commonly known as the area code.
        /// </summary>
        public string NPA { get; set; }

        /// <summary>
        /// Three digits following the NPA (area code) in the available number.
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        /// The available phone numbers city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The region of the available phone number. Usually a two letter abbreviation.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The postal code (also known as zip code) of the available number.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Two letter country code of the available phone number.
        /// </summary>
        public string IsoCountry { get; set; }

        /// <summary>
        /// Type of phone number. (e.g. local, international, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Cost of phone number setup.
        /// </summary>
        public decimal SetupCost { get; set; }

        /// <summary>
        /// Cost of phone number per month.
        /// </summary>
        public decimal MonthlyCost { get; set; }

        /// <summary>
        /// Is Voice enabled for this phone number
        /// </summary>
        public bool VoiceEnabled { get; set; }

        /// <summary>
        /// Is SMS enabled for this phone number
        /// </summary>
        public bool SmsEnabled { get; set; }

        /// <summary>
        /// Does phone number support forwarded from
        /// </summary>
        public bool SupportsForwardedFrom { get; set; }
    }
}

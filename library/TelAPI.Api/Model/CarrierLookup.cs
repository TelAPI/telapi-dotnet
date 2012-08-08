using System;

namespace TelAPI
{
    public class CarrierLookup : TelAPIBase
    {
        /// <summary>
        /// The Api Version being used when the CNAM look up was made.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// An alphanumeric string used for identification of the CNAM look up resource.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this look up occurred through.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// Date the CNAM look up resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date the CNAM look up resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The phone number the look up was performed on.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The carrier of the phone number we are looking up.
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// Cost of the look up.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Specifies if the phone number is mobile. can be true or false.
        /// </summary>
        public bool IsMobile { get; set; }

        /// <summary>
        /// Code used to identify the phone numbers geographic origin. Found at the beginning of the number.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Carrier Identification Code. A four digit code used to route and switch calls.
        /// </summary>
        public string CICCode { get; set; }

        /// <summary>
        /// The path appended to the base TelAPI URL, https://api.telapi.com, where the resource is located.
        /// </summary>
        public string Url { get; set; }
    }
}

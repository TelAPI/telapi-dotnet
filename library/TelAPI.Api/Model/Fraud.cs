using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class Fraud : TelAPIBase
    {
        public Outbound Outbound { get; set; }
    }

    public class Outbound
    {
        /// <summary>
        /// The price limit an outbound call may be. Calls which cost more will be rejected.
        /// </summary>
        public decimal MaxOutboundRate { get; set; }
        public Destinations Destinations { get; set; }
    }

    public class Destinations
    {
        public Country Blocked { get; set; }
        public Country Authorized { get; set; }
        public Country Whitelisted { get; set; }
    }

    public class Country
    {
        /// <summary>
        /// Full name of the destination being whitelisted, authorized or blocked.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Two letter country code being whitelisted, authorized or blocked.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Prefix of the destination being whitelisted, authorized or blocked.
        /// </summary>
        public string CountryPrefix { get; set; }

        /// <summary>
        /// Mobile breakout status of the destination. Can be true or false.
        /// </summary>
        public bool MobileBreakout { get; set; }

        /// <summary>
        /// Landline breakout status of the destination. Can be true or false.
        /// </summary>
        public bool LandlineBreakout { get; set; }

        /// <summary>
        /// Status of the SMS for destination. Can be true or false. If false, SMS for same destination will be rejected.
        /// </summary>
        public bool SmsEnabled { get; set; }

        /// <summary>
        /// The date the fraud control resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the fraud control resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The date the fraud control resource will expire.
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}

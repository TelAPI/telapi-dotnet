using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class SmsMessageListOptions
    {
        /// <summary>
        /// Lists all SMS messages sent to this number.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Lists all SMS messages sent from this number.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Lists all SMS messages beginning on or from a certain date. Date range can be specified using inequalities like so: DateSent>=YYYY-MM-DD or DateSent<=YYYY-MM-DD.
        /// </summary>
        public DateTime? DateSent { get; set; }

        /// <summary>
        /// Comparison type for date sent
        /// </summary>
        public ComparisonType DateSentComparison { get; set; }

        /// <summary>
        /// Used to return a particular page withing the list.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Used to specify the amount of list items to return per page.
        /// </summary>
        public int? PageSize { get; set; }
    }
}

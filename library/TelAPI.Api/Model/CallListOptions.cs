using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelAPI
{
    public class CallListOptions
    {
        /// <summary>
        /// Lists all calls made to this number only.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Lists all calls made from this number.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Lists all calls with the specified status only.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Lists all calls beginning on or from a certain date. Date range can be specified using inequalities like so: DateSent>=YYYY-MM-DD or DateSent<=YYYY-MM-DD.
        /// </summary>
        public DateTime? StartTime { get; set; }

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

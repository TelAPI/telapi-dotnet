using System.Globalization;
using Newtonsoft.Json;
using System;

namespace TelAPI
{
    public class Usage : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string identifying the usage resource.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }
        
        /// <summary>
        /// The product or feature used.
        /// </summary>
        [JsonProperty(PropertyName = "product")]
        public string Product { get; set; }
        
        /// <summary>
        /// The day of the usage.
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public string Day { get; set; }
        
        /// <summary>
        /// The month of the usage.
        /// </summary>
        [JsonProperty(PropertyName = "month")]
        public string Month { get; set; }
        
        /// <summary>
        /// The year of the usage.
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }
        
        /// <summary>
        /// The quantity of the usage.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        
        /// <summary>
        /// The average cost of this usage.
        /// </summary>
        [JsonProperty(PropertyName = "average_cost")]
        public decimal AverageCost { get; set; }
        
        /// <summary>
        /// The total cost for all usage.
        /// </summary>
        [JsonProperty(PropertyName = "total_cost")]
        public decimal TotalCost { get; set; }

        public DateTime Date
        {
            get { return DateTime.ParseExact(Day + "." + Month + "." + Year , "dd.M.yyyy", CultureInfo.InvariantCulture); }
        }
    }
}

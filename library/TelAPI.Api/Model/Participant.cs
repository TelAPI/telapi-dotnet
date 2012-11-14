using Newtonsoft.Json;
using System;

namespace TelAPI
{
    public class Participant : TelAPIBase
    {
        /// <summary>
        /// Call sid
        /// </summary>
        [JsonProperty(PropertyName = "call_sid")]
        public string CallSid { get; set; }
        
        /// <summary>
        /// Conference sid
        /// </summary>
        [JsonProperty(PropertyName = "conference_sid")]
        public string ConferenceSid { get; set; }
        
        /// <summary>
        /// Account sid
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// Muted
        /// </summary>
        [JsonProperty(PropertyName = "muted")]
        public bool Muted { get; set; }

        /// <summary>
        /// Deaf
        /// </summary>
        [JsonProperty(PropertyName = "deaf")]
        public bool Deaf { get; set; }

        /// <summary>
        /// Caller name
        /// </summary>
        [JsonProperty(PropertyName = "caller_name")]
        public string CallerName { get; set; }

        /// <summary>
        /// Caller number
        /// </summary>
        [JsonProperty(PropertyName = "caller_number")]
        public string CallerNumber { get; set; }
        
        /// <summary>
        /// Duration
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Date created
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date updated
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }
    }
}

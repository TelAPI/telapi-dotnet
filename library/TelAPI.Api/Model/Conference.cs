using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelAPI
{
    public class Conference : TelAPIBase
    {
        /// <summary>
        /// A 34 long unique conference identifier.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// User generated name of the conference.
        /// </summary>
        [JsonProperty(PropertyName = "friendly_name")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account the conference occurred through.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// The number of members that participated in the conference.
        /// </summary>
        [JsonProperty(PropertyName = "participant_count")]
        public int ParticipantCount { get; set; }

        /// <summary>
        /// Conference duration in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "run_time")]
        public int RunTime { get; set; }

        /// <summary>
        /// Conference status. Can be 'init', 'in-progress' or 'completed'.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Date when conference was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date when conference was updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }
    }
}

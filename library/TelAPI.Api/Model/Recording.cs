using Newtonsoft.Json;
using System;

namespace TelAPI
{
    public class Recording : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used to identify each recording.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this recording occurred through.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }

        /// <summary>
        /// The sid identifying the recorded call.
        /// </summary>
        [JsonProperty(PropertyName = "call_sid")]
        public string CallSid { get; set; }

        /// <summary>
        /// Time of recording in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }

        /// <summary>
        /// The date the recording resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the recording resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The Api Version being used when the recording was made.
        /// </summary>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// URL where .mp3 or .wav file of the recording is located.
        /// </summary>
        [JsonProperty(PropertyName = "recording_url")]
        public string RecordingUrl { get; set; }

    }
}

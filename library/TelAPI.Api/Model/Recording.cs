using System;

namespace TelAPI
{
    public class Recording : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used to identify each recording.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account this recording occurred through.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// The sid identifying the recorded call.
        /// </summary>
        public string CallSid { get; set; }

        /// <summary>
        /// Time of recording in seconds.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The date the recording resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the recording resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The Api Version being used when the recording was made.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// URL where .mp3 or .wav file of the recording is located.
        /// </summary>
        public string RecordingUrl { get; set; }

        /// <summary>
        /// The path appended to the base TelAPI URL, https://api.telapi.com, where the resource is located.
        /// </summary>
        public string Url { get; set; }
    }
}

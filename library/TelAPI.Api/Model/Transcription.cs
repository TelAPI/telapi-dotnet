using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TelAPI
{
    public class Transcription : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used for identification of transcriptions.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }
        
        /// <summary>
        /// An alphanumeric string identifying the account this transcription occurred through.        
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }
        
        /// <summary>
        /// The date the transcription resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }
        
        /// <summary>
        /// /The date the transcription resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }
        
        /// <summary>
        /// Status of the transcription. May be in-progress, completed, or failed.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TranscriptionStatus Status { get; set; }
        
        /// <summary>
        /// Transcription quality tier. May be auto, silver, gold, or platinum. Default is auto.
        /// </summary>
        [JsonProperty(PropertyName = "transcription_type")]
        public TranscriptionType Type { get; set; }

        /// <summary>
        /// URL where a file containing the transcribed audio is located
        /// </summary>
        [JsonProperty(PropertyName = "audio_url")]
        public string AudioUrl { get; set; }

        /// <summary>
        /// An alphanumeric string used to identify the recording that was transcribed.
        /// </summary>
        [JsonProperty(PropertyName = "recording_sid")]
        public string RecordingSid { get; set; }

        /// <summary>
        /// Length in seconds of the transcribed recording.
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Text of the transcribed audio.
        /// </summary>
        [JsonProperty(PropertyName = "transcription_text")]
        public string TranscriptionText { get; set; }

        /// <summary>
        /// The Api Version being used when the transcription was made.
        /// </summary>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Cost of the transcription.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// URL where transcription will report to after completion.
        /// </summary>
        [JsonProperty(PropertyName = "transcribe_callback")]
        public string TranscribeCallback { get; set; }

        /// <summary>
        /// Method to request TranscribeCallback URL. Can be POST or GET. Default is POST
        /// </summary>
        [JsonProperty(PropertyName = "callback_method")]
        public string CallbackMethod { get; set; }
    }
}

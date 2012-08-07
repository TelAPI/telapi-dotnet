using System;

namespace TelAPI
{
    public class Transcription : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string used for identification of transcriptions.
        /// </summary>
        public string Sid { get; set; }
        
        /// <summary>
        /// An alphanumeric string identifying the account this transcription occurred through.        
        /// </summary>
        public string AccountSid { get; set; }
        
        /// <summary>
        /// The date the transcription resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        
        /// <summary>
        /// /The date the transcription resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        
        /// <summary>
        /// Status of the transcription. May be in-progress, completed, or failed.
        /// </summary>
        public TranscriptionStatus Status { get; set; }
        
        /// <summary>
        /// Transcription quality tier. May be auto, silver, gold, or platinum. Default is auto.
        /// </summary>
        public TranscriptionType Type { get; set; }

        /// <summary>
        /// URL where a file containing the transcribed audio is located
        /// </summary>
        public string AudioUrl { get; set; }

        /// <summary>
        /// An alphanumeric string used to identify the recording that was transcribed.
        /// </summary>
        public string RecordingSid { get; set; }

        /// <summary>
        /// Length in seconds of the transcribed recording.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Text of the transcribed audio.
        /// </summary>
        public string TranscriptionText { get; set; }

        /// <summary>
        /// The Api Version being used when the transcription was made.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Cost of the transcription.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// URL where transcription will report to after completion.
        /// </summary>
        public string TranscribeCallback { get; set; }

        /// <summary>
        /// Method to request TranscribeCallback URL. Can be POST or GET. Default is POST
        /// </summary>
        public string CallbackMethod { get; set; }

        /// <summary>
        /// The path appended to the base TelAPI URL, https://api.telapi.com, where the resource is located.
        /// </summary>
        public string Url { get; set; }
    }
}

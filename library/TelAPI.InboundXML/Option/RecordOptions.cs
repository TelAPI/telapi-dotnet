using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Option
{
    /// <summary>
    /// Class that contains all possible Record options
    /// </summary>
    public class RecordOptions
    {
        /// <summary>
        /// URL where some parameters specific to <Record> will be sent for further processing.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Specifies the method to use when requesting the action or transcribeCallback URL.
        /// </summary>
        public HttpMethod? Method { get; set; }

        /// <summary>
        /// The number of seconds <Record> should wait during silence before ending.
        /// </summary>
        public long? Timeout { get; set; }

        /// <summary>
        /// The key a caller can press to end the <Record>.
        /// </summary>
        public string FinishOnKey { get; set; }

        /// <summary>
        /// The maximum length in seconds a recording should be.
        /// </summary>
        public long? MaxLength { get; set; }

        /// <summary>
        /// Boolean value specifying if the recording should be transcribed.
        /// </summary>
        public bool? Transcribe { get; set; }

        /// <summary>
        /// URL where the recording transcription will be sent.
        /// </summary>
        public string TranscribeCallback { get; set; }

        /// <summary>
        /// Boolean value specifying if a beep should be played when the recording begins.
        /// </summary>
        public bool? PlayBeep { get; set; }

        /// <summary>
        /// Boolean value specifying if both call legs should be recorded.
        /// </summary>
        public bool? BothLegs { get; set; }

        /// <summary>
        /// The recording file format. Can be mp3 or wav. Default is mp3.
        /// </summary>
        public RecordingFileFormat? FileFormat { get; set; }
    }
}

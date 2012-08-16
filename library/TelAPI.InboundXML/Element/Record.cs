using System;
using System.Collections.Generic;
using YAXLib;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Record")]
    public class Record : ELement
    {
        [YAXAttributeForClass]
        [YAXSerializeAs("action")]
        public string Action { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("method")]
        public string Method { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("timeout")]
        public string Timeout { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("finishOnKey")]
        public string FinishOnKey { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("maxLength")]
        public string MaxLength { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("transcribe")]
        public string Transcribe { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("transcribeCallback")]
        public string TranscribeCallback { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("playBeep")]
        public string PlayBeep { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("bothLegs")]
        public string BothLegs { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("fileFormat")]
        public string FileFormat { get; set; }

        public Record()
        {

        }

        /// <summary>
        /// The Record element is used to record audio during a call.
        /// </summary>
        /// <param name="action">URL where some parameters specific to <Record> will be sent for further processing.</param>
        /// <returns></returns>
        public static Record Create(string action)
        {
            Record record = new Record();
            record.Action = action;

            return record;
        }

        /// <summary>
        /// The Record element is used to record audio during a call.
        /// </summary>
        /// <param name="action">URL where some parameters specific to <Record> will be sent for further processing.</param>
        /// <param name="method">Specifies the method to use when requesting the action or transcribeCallback URL.</param>
        /// <param name="timeout">The number of seconds Record should wait during silence before ending.</param>
        /// <param name="finishOnKey">The key a caller can press to end the Record.</param>
        /// <param name="maxLength">The maximum length in seconds a recording should be.</param>
        /// <param name="transcribe">Boolean value specifying if the recording should be transcribed.</param>
        /// <param name="transcribeCallback">URL where the recording transcription will be sent.</param>
        /// <param name="playBeep">Boolean value specifying if a beep should be played when the recording begins.</param>
        /// <param name="bothLegs">Boolean value specifying if both call legs should be recorded.</param>
        /// <param name="fileFormat">The recording file format. Can be mp3 or wav. Default is mp3.</param>
        /// <returns></returns>
        public static Record Create(string action, HttpMethod? method, long? timeout, string finishOnKey, long? maxLength, bool? transcribe, string transcribeCallback, bool? playBeep, bool? bothLegs, RecordingFileFormat? fileFormat)
        {
            Record record = new Record();

            record.Action = action;
            record.Method = method == null ? null : method.ToString();
            record.Timeout = timeout == null ? null : timeout.ToString().ToLower();
            record.FinishOnKey = finishOnKey;
            record.MaxLength = maxLength == null ? null : maxLength.ToString();
            record.Transcribe = transcribe == null ? null : transcribe.ToString().ToLower();
            record.TranscribeCallback = transcribeCallback;
            record.PlayBeep = playBeep == null ? null : playBeep.ToString().ToLower();
            record.BothLegs = bothLegs == null ? null : bothLegs.ToString().ToLower();
            record.FileFormat = fileFormat == null ? null : fileFormat.ToString();
            
            return record;
        }
    }
}

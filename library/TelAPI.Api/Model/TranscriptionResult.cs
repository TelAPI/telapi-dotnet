using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class TranscriptionResult : TelAPIListBase
    {
        public List<Transcription> Transcriptions { get; set; }
    }
}

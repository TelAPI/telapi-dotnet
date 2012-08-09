using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class TranscriptionTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Transcribe_Audio()
        {
            var transcribe = _client.TranscribeAudio("http://www.test.hr");

            Assert.NotNull(transcribe);
        }

        [Fact]
        public void Can_I_Get_Transcription()
        {
            var list = _client.GetAccountTranscriptions();
            var transcription = list.Transcriptions[0];

            var transcriptionToCheck = _client.GetTranscription(transcription.Sid);

            Assert.NotNull(transcriptionToCheck);
        }

        [Fact]
        public void Can_I_Get_Transcription_Text()
        {
            var transcribe = _client.TranscribeAudio("http://www.test.hr");
            var text = _client.GetTranscriptionText(transcribe.Sid);

            Assert.NotNull(text);
        }

        [Fact]
        public void Can_I_Get_Account_Transcriptions()
        {
            var transcriptions = _client.GetAccountTranscriptions();

            Assert.NotNull(transcriptions);
        }

        [Fact]
        public void Can_I_Recort_Transcriptions()
        {
            var list = _client.GetAccountRecordings();
            var recording = list.Recordings[0];

            var transcriptionToCheck = _client.TranscribeRecording(recording.Sid);

            Assert.NotNull(transcriptionToCheck);
        }
    }
}

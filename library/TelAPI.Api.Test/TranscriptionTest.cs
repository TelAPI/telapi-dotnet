using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class TranscriptionTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Transcribe_Audio()
        {
            var transcribe = Client.TranscribeAudio(TranscribeAudioUrl);

            Assert.Equal(transcribe.Status, TranscriptionStatus.InProgress);
            Assert.NotNull(transcribe);
        }

        [Fact]
        public void Can_I_Get_Transcription()
        {
            var list = Client.GetAccountTranscriptions();
            var transcription = list.Transcriptions[0];

            var transcriptionToCheck = Client.GetTranscription(transcription.Sid);

            Assert.NotNull(transcriptionToCheck);
        }

        [Fact]
        public void Can_I_Get_Transcription_Text()
        {
            var transcribe = Client.TranscribeAudio(TranscribeAudioUrl);
            var text = Client.GetTranscriptionText(transcribe.Sid);

            Assert.NotNull(text);
        }

        [Fact]
        public void Can_I_Get_Account_Transcriptions()
        {
            var transcriptions = Client.GetAccountTranscriptions();

            Assert.NotNull(transcriptions);
        }

        [Fact]
        public void Can_I_Record_Transcriptions()
        {
            var list = Client.GetAccountRecordings();
            var recording = list.Recordings[0];

            var transcriptionToCheck = Client.TranscribeRecording(recording.Sid);

            Assert.NotNull(transcriptionToCheck);
        }
    }
}

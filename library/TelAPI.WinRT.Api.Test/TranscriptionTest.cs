using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class TranscriptionTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Transcribe_Audio()
        {
            var transcribe = await Client.TranscribeAudio(TranscribeAudioUrl);

            Assert.Equal(transcribe.Status, TranscriptionStatus.InProgress);
            Assert.NotNull(transcribe);
        }

        [Fact]
        public async Task Can_I_Get_Transcription()
        {
            var list = await Client.GetAccountTranscriptions();
            var transcription = list.Transcriptions[0];

            var transcriptionToCheck = await Client.GetTranscription(transcription.Sid);

            Assert.NotNull(transcriptionToCheck);
        }

        [Fact]
        public async Task Can_I_Get_Transcription_Text()
        {
            var transcribe = await Client.TranscribeAudio(TranscribeAudioUrl);
            var text = Client.GetTranscriptionText(transcribe.Sid);

            Assert.NotNull(text);
        }

        [Fact]
        public async Task Can_I_Get_Account_Transcriptions()
        {
            var transcriptions = await Client.GetAccountTranscriptions();

            Assert.NotNull(transcriptions);
        }

        [Fact]
        public async Task Can_I_Record_Transcriptions()
        {
            var list = await Client.GetAccountRecordings();
            var recording = list.Recordings[0];

            var transcriptionToCheck = await Client.TranscribeRecording(recording.Sid);

            Assert.NotNull(transcriptionToCheck);
        }
    }
}

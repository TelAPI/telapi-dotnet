using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class RecordingTest :  TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Recording()
        {
            var list = _client.GetAccountRecordings();
            var recording = list.Recordings[0];

            var recordingToCheck = _client.GetRecording(recording.Sid);

            Assert.Equal(recording.Sid, recordingToCheck.Sid);
        }

        [Fact]
        public void Can_I_Get_Account_Recordings()
        {
            var recordings = _client.GetAccountRecordings();

            Assert.NotNull(recordings);
        }

        [Fact]
        public void Can_I_Get_Call_Recordings()
        {
            var list = _client.GetCalls();
            var call = list.Calls[0];

            var recording = _client.GetCallRecordings(call.Sid);

            Assert.NotNull(recording);
        }
    }
}

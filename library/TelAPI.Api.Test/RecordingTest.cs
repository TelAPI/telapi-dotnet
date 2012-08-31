using System;
using Xunit;
using System.Threading;

namespace TelAPI.Api.Test
{
    public class RecordingTest :  TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Recording()
        {
            var recording = Client.GetRecording("RE20f5e4f35cc247b088026f72a1b87318");
            Assert.NotNull(recording);

            Console.WriteLine("{0}", recording.DateCreated);
        }

        [Fact]
        public void Can_I_Get_Account_Recordings()
        {
            var recordings = Client.GetAccountRecordings();
            Assert.NotNull(recordings);

            foreach (var recording in recordings.Recordings)
            {
                Console.WriteLine("{0}", recording.DateCreated);
            }
        }

        [Fact]
        public void Can_I_Get_Call_Recordings()
        {
            var recordings = Client.GetCallRecordings("CAe1a4b86a63ea40a5ac80fad6fdff9065");
            Assert.NotNull(recordings);

            foreach (var recording in recordings.Recordings)
            {
                Console.WriteLine("{0}", recording.DateCreated);
            }
        }
    }
}

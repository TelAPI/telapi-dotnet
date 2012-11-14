using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;
using System.Threading;

namespace TelAPI.Api.Test
{
    public class RecordingTest :  TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Recording()
        {
            var recording = await Client.GetRecording(RecordingSid);
            Assert.NotNull(recording);
        }

        [Fact]
        public async Task Can_I_Get_Account_Recordings()
        {
            var recordings = await Client.GetAccountRecordings();
            Assert.NotNull(recordings);
        }

        [Fact]
        public async Task Can_I_Get_Account_Recordings_DateComparasion()
        {
            var recordings = await Client.GetAccountRecordings(new DateTime(2012, 8, 20), ComparisonType.GreaterThanOrEqualTo,
                                                         null, null);

            foreach (var rec in recordings.Recordings)
            {
                Debug.WriteLine("rec sid : {0} date : {1}", rec.Sid, rec.DateCreated);
            }

            Assert.NotNull(recordings);
        }

        [Fact]
        public async Task Can_I_Get_Call_Recordings()
        {
            var recordings = await Client.GetCallRecordings(RecordingCallSid);
            Assert.NotNull(recordings);

            foreach (var rec in recordings.Recordings)
            {
                Debug.WriteLine("rec sid : {0} date : {1}", rec.Sid, rec.DateCreated);
            }

        }

        [Fact]
        public async Task Can_I_Get_Call_Recordings_DateComparasion()
        {
            var recordings = await Client.GetCallRecordings(RecordingCallSid, new DateTime(2012, 8, 20), ComparisonType.LessThanOrEqualTo, null, null);
            Assert.NotNull(recordings);

            foreach (var rec in recordings.Recordings)
            {
                Debug.WriteLine("rec sid : {0} date : {1}", rec.Sid, rec.DateCreated);
            }

        }
    }
}

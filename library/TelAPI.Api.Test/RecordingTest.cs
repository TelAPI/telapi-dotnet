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
            var recording = Client.GetRecording(RecordingSid);
            Assert.NotNull(recording);
        }

        [Fact]
        public void Can_I_Get_Account_Recordings()
        {
            var recordings = Client.GetAccountRecordings();
            Assert.NotNull(recordings);
        }

        [Fact]
        public void Can_I_Get_Account_Recordings_DateComparasion()
        {
            var recordings = Client.GetAccountRecordings(new DateTime(2012, 8, 20), ComparisonType.GreaterThanOrEqualTo,
                                                         null, null);

            foreach (var rec in recordings.Recordings)
            {
                Console.WriteLine("rec sid : {0} date : {1}", rec.Sid, rec.DateCreated);
            }

            Assert.NotNull(recordings);
        }

        [Fact]
        public void Can_I_Get_Call_Recordings()
        {
            var recordings = Client.GetCallRecordings(RecordingCallSid);
            Assert.NotNull(recordings);

            foreach (var rec in recordings.Recordings)
            {
                Console.WriteLine("rec sid : {0} date : {1}", rec.Sid, rec.DateCreated);
            }

        }

        [Fact]
        public void Can_I_Get_Call_Recordings_DateComparasion()
        {
            var recordings = Client.GetCallRecordings(RecordingCallSid, new DateTime(2012, 8, 20), ComparisonType.LessThanOrEqualTo, null, null);
            Assert.NotNull(recordings);

            foreach (var rec in recordings.Recordings)
            {
                Console.WriteLine("rec sid : {0} date : {1}", rec.Sid, rec.DateCreated);
            }

        }
    }
}

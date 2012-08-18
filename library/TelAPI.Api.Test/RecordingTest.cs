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
            //
        }

        [Fact]
        public void Can_I_Get_Account_Recordings()
        {
            var recordings = Client.GetAccountRecordings();
            Assert.NotNull(recordings);
        }

        [Fact]
        public void Can_I_Get_Call_Recordings()
        {
            //
        }
    }
}

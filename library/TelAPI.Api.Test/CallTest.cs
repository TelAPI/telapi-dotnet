using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class CallTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Call_List()
        {
            var calls = _client.GetCalls();

            Assert.NotNull(calls);
        }

        [Fact]
        public void Can_I_Get_Call_List_With_Condition()
        {
            var pageSize = 2;
            var options = new CallListOptions();            
            options.PageSize = pageSize;

            var calls = _client.GetCalls(options);

            Assert.NotNull(calls);
            Assert.Equal(pageSize, calls.PageSize);
        }

        [Fact]
        public void Can_I_Make_And_Get_Call()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.GetCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Hangup_Call()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Interrupt_Call()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.InterruptLiveCall(call.Sid, "http://www.test.com", HttpMethod.Get, HangupCallStatus.Canceled);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Send_Digits()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.SendDigits(call.Sid, "12ww12", PlayDtmfLeg.Aleg);
            _client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Play_Sound()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.PlayAudio(call.Sid, "http://www.telapi.com/ivr/welcome/call");
            _client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Set_Voice_Effect()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.VoiceEffects(call.Sid, new VoiceEffectOptions
            {
                Pitch = 1,
                Rate = 1
            });

            _client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Record_Call()
        {
            var call = _client.MakeCall("+123456789", "+123456788", "http://www.telapi.com/ivr/call");
            var receivedCall = _client.RecordCall(call.Sid, true);

            Assert.NotNull(receivedCall);
            Assert.Equal(call.Sid, receivedCall.Sid);

            var stopedCall = _client.RecordCall(receivedCall.Sid, false);

            Assert.NotNull(stopedCall);
            Assert.Equal(receivedCall.Sid, stopedCall.Sid);

            _client.HangupCall(call.Sid);
        }

    }
}

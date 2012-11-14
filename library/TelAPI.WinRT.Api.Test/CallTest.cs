using System;
using System.Threading.Tasks;
using Xunit;
using System.Threading;

namespace TelAPI.Api.Test
{
    public class CallTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Call_List()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var calls = await Client.GetCalls();

            var receivedCall = await Client.HangupCall(call.Sid);

            Assert.NotNull(calls);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Get_Call_List_With_Condition()
        {
            var pageSize = 1;
            var options = new CallListOptions();            
            options.PageSize = pageSize;

            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var calls = await Client.GetCalls(options);

            var receivedCall = await Client.HangupCall(call.Sid);

            Assert.NotNull(calls);
            Assert.Equal(pageSize, calls.PageSize);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Get_Call_List_With_StartTimeComparasion()
        {
            var options = new CallListOptions();
            options.StartTimeComaparasion = ComparisonType.GreaterThanOrEqualTo;
            options.StartTime = new DateTime(2012, 8, 5);

            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var calls = await Client.GetCalls(options);

            var receivedCall = await Client.HangupCall(call.Sid);
            
            Assert.NotNull(calls);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Make_And_Get_And_Hangup_Call()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = await Client.GetCall(call.Sid);
            var hangupCall = await Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.NotNull(receivedCall);
            Assert.NotNull(hangupCall);
            Assert.Equal(call.Sid, receivedCall.Sid);
            Assert.Equal(call.Sid, hangupCall.Sid);
        }

        [Fact]
        public async Task Can_I_Make_Call_With_Options()
        {
            var options = new CallOptions();
            options.From = PhoneNumberFrom;
            options.To = PhoneNumberTo;
            options.Url = ActionUrl;
            options.HeartbeatMethod = HttpMethod.Get;
            options.HeartbeatUrl = "http://some-url.com";
            options.Record = true;
            options.RecordCallback = "http://record.com";

            var receivedCall = await Client.MakeCall(options);
            var hangupCall = await Client.HangupCall(receivedCall.Sid);

            Assert.NotNull(receivedCall);
            Assert.Equal(receivedCall.Sid, hangupCall.Sid);
        }

        [Fact]
        public async Task Can_I_Make_And_Interrupt_Call()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = await Client.InterruptLiveCall(call.Sid, ActionUrl, HttpMethod.Post, HangupCallStatus.Canceled);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Send_Digits_To_Call()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = await Client.SendDigits(call.Sid, "12ww12", PlayDtmfLeg.Aleg);
            
            await Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Play_Sound_On_Call()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = await Client.PlayAudio(call.Sid,AudioUrl);
            await Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Set_Voice_Effect()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = await Client.VoiceEffects(call.Sid, new VoiceEffectOptions
            {
                Pitch = -0.5,
                Rate = 0,
                PitchOctaves = -0.6,
                AudioDirection = AudioDirection.In,
                Tempo = 5.5
            });

            await Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public async Task Can_I_Record_Call()
        {
            var call = await Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = await Client.RecordCall(call.Sid, true);

            Assert.NotNull(receivedCall);

            var stopedCall = await Client.RecordCall(call.Sid, false);
            await Client.HangupCall(call.Sid);

            Assert.NotNull(stopedCall);
        }

    }
}

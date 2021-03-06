﻿using System;
using Xunit;
using System.Threading;

namespace TelAPI.Api.Test
{
    public class CallTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Call_List()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var calls = Client.GetCalls();

            var receivedCall = Client.HangupCall(call.Sid);

            Assert.NotNull(calls);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Get_Call_List_With_Condition()
        {
            var pageSize = 1;
            var options = new CallListOptions();            
            options.PageSize = pageSize;

            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var calls = Client.GetCalls(options);

            var receivedCall = Client.HangupCall(call.Sid);

            Assert.NotNull(calls);
            Assert.Equal(pageSize, calls.PageSize);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Get_Call_List_With_StartTimeComparasion()
        {
            var options = new CallListOptions();
            options.StartTimeComaparasion = ComparisonType.GreaterThanOrEqualTo;
            options.StartTime = new DateTime(2012, 8, 5);

            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var calls = Client.GetCalls(options);

            var receivedCall = Client.HangupCall(call.Sid);

            foreach (var c in calls.Calls)
            {
                Console.WriteLine("call sid : {0} date: {1}", c.Sid, c.StartTime);
            }

            Assert.NotNull(calls);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Make_And_Get_And_Hangup_Call()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = Client.GetCall(call.Sid);
            var hangupCall = Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.NotNull(receivedCall);
            Assert.NotNull(hangupCall);
            Assert.Equal(call.Sid, receivedCall.Sid);
            Assert.Equal(call.Sid, hangupCall.Sid);
        }

        [Fact]
        public void Can_I_Make_Call_With_Options()
        {
            var callOptions = new CallOptions();

            callOptions.From = PhoneNumberFrom;
            callOptions.To = PhoneNumberTo;
            callOptions.Url = "http://liveoutput.com/EATCN84c";
            callOptions.Method = HttpMethod.Get;
            callOptions.Timeout = 5;
            callOptions.SendDigits = "5";
            callOptions.StatusCallback = "http://liveoutput.com/EATCN84c";
            callOptions.StatusCallbackMethod = HttpMethod.Post;
            callOptions.FallbackUrl = "http://liveoutput.com/EATCN84c";
            callOptions.FallbackMethod = HttpMethod.Get;
            callOptions.HeartbeatUrl = "http://liveoutput.com/EATCN84c";
            callOptions.HeartbeatMethod = HttpMethod.Get;
            callOptions.HideCallerId = false;
            callOptions.Record = false;
            callOptions.RecordCallback = "http://liveoutput.com/EATCN84c";
            callOptions.RecordCallbackMethod = HttpMethod.Post;
            callOptions.Transcribe = true;
            callOptions.TranscribeCallback = "http://liveoutput.com/EATCN84c";

            var receivedCall = Client.MakeCall(callOptions);
            var hangupCall = Client.HangupCall(receivedCall.Sid);

            Assert.NotNull(receivedCall);
            Assert.Equal(receivedCall.Sid, hangupCall.Sid);
        }

        [Fact]
        public void Can_I_Make_And_Interrupt_Call()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = Client.InterruptLiveCall(call.Sid, null, null, null);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Send_Digits_To_Call()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = Client.SendDigits(call.Sid, "12ww12", PlayDtmfLeg.Aleg);
            
            Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Play_Sound_On_Call()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = Client.PlayAudio(call.Sid,AudioUrl);
            Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Set_Voice_Effect()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = Client.VoiceEffects(call.Sid, new VoiceEffectOptions
            {
                Pitch = -0.5,
                Rate = 0,
                PitchOctaves = -0.6,
                AudioDirection = AudioDirection.In,
                Tempo = 5.5
            });

            Client.HangupCall(call.Sid);

            Assert.NotNull(call);
            Assert.Equal(call.Sid, receivedCall.Sid);
        }

        [Fact]
        public void Can_I_Record_Call()
        {
            var call = Client.MakeCall(PhoneNumberFrom, PhoneNumberTo, ActionUrl);
            var receivedCall = Client.RecordCall(call.Sid, true);

            Assert.NotNull(receivedCall);

            var stopedCall = Client.RecordCall(call.Sid, false);
            Client.HangupCall(call.Sid);

            Assert.NotNull(stopedCall);
        }

    }
}

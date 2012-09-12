using System;
using Xunit;
using System.Collections.Generic;

namespace TelAPI.Api.Test
{
    public class ConferenceTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Conference()
        {
            var conferences = Client.GetConferences();
            var conference = Client.GetConference(conferences.Conferences[0].Sid);
            Assert.NotNull(conference);
        }

        [Fact]
        public void Can_I_Get_Conference_List()
        {
            var conferences = Client.GetConferences();
            Assert.NotNull(conferences);
        }

        [Fact]
        public void Can_I_Mute_Participant()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = Client.GetConferenceParticipants(conference.Sid)[0];

            var status = Client.MuteParticipant(conference.Sid, member, true);

            Assert.NotNull(status);
           
        }

        [Fact]
        public void Can_I_Unmute_Participant()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = Client.GetConferenceParticipants(conference.Sid)[0];

            var status = Client.MuteParticipant(conference.Sid, member, false);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Deaf_Participant()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = Client.GetConferenceParticipants(conference.Sid)[0];

            var status = Client.DeafParticipant(conference.Sid, member, true);
           

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Undeaf_Participant()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = Client.GetConferenceParticipants(conference.Sid)[0];

            var status = Client.DeafParticipant(conference.Sid, member, false);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Hangup_Participant()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = Client.GetConferenceParticipants(conference.Sid)[0];

            var status = Client.HangupParticipant(conference.Sid, member);
            
            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Play_Audio_To_Participant()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = Client.GetConferenceParticipants(conference.Sid)[0];

            var status = Client.PlayAudioToParticipant(conference.Sid, member, "http://funny-stuff.audio4fun.com/download/audioclips/159.mp3");

            Assert.NotNull(status);
        }
    }
}

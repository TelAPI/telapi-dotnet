using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace TelAPI.Api.Test
{
    public class ConferenceTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Conference()
        {
            var conferences = await Client.GetConferences();
            var conference = await Client.GetConference(conferences.Conferences[0].Sid);
            Assert.NotNull(conference);
        }

        [Fact]
        public async Task Can_I_Get_Conference_List()
        {
            var conferences = await Client.GetConferences();
            Assert.NotNull(conferences);
        }

        [Fact]
        public async Task Can_I_Mute_Participant()
        {
            var conference = await Client.GetConference(ConferenceSid);
            var member = await Client.GetConferenceParticipants(conference.Sid);

            var status = await Client.MuteParticipant(conference.Sid, member[0], true);

            Assert.NotNull(status);
           
        }

        [Fact]
        public async Task Can_I_Unmute_Participant()
        {
            var conference = await Client.GetConference(ConferenceSid);
            var member = await Client.GetConferenceParticipants(conference.Sid);

            var status = await Client.MuteParticipant(conference.Sid, member[0], false);

            Assert.NotNull(status);
        }

        [Fact]
        public async Task Can_I_Deaf_Participant()
        {
            var conference = await Client.GetConference(ConferenceSid);
            var member = await Client.GetConferenceParticipants(conference.Sid);

            var status = Client.DeafParticipant(conference.Sid, member[0], true);

            Assert.NotNull(status);
        }

        [Fact]
        public async Task Can_I_Undeaf_Participant()
        {
            var conference = await Client.GetConference(ConferenceSid);
            var member = await Client.GetConferenceParticipants(conference.Sid);

            var status = await Client.DeafParticipant(conference.Sid, member[0], false);

            Assert.NotNull(status);
        }

        [Fact]
        public async Task Can_I_Hangup_Participant()
        {
            var conference = await Client.GetConference(ConferenceSid);
            var member = await Client.GetConferenceParticipants(conference.Sid);

            var status = await Client.HangupParticipant(conference.Sid, member[0]);
            
            Assert.NotNull(status);
        }

        [Fact]
        public async Task Can_I_Play_Audio_To_Participant()
        {
            var conference = await Client.GetConference(ConferenceSid);
            var member = await Client.GetConferenceParticipants(conference.Sid);

            var status = await Client.PlayAudioToParticipant(conference.Sid, member[0], "http://funny-stuff.audio4fun.com/download/audioclips/159.mp3");

            Assert.NotNull(status);
        }
    }
}

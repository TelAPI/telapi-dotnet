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
            var conference = Client.GetConference(ConferenceName);
            Assert.NotNull(conference);
        }

        [Fact]
        public void Can_I_Get_Conference_List()
        {
            var conferences = Client.GetConferences();
            Assert.NotNull(conferences);
        }

        [Fact]
        public void Can_I_Mute_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.MuteMember(conference.Name, member);

            Assert.NotNull(status);
           
        }

        [Fact]
        public void Can_I_Unmute_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.UnmuteMember(conference.Name, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Deaf_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.DeafMember(conference.Name, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Undeaf_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.UndeafMember(conference.Name, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Hangup_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.HangupMember(conference.Name, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Kick_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.KickMember(conference.Name, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Speak_Text_To_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.SpeakTextToMember(conference.Name, member, "hello world. I'm conference robot");

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Play_Audio_To_Member()
        {
            var conferences = Client.GetConference(ConferenceName);
            var conference = conferences.Conferences[0];
            var member = conference.Members[0];

            var status = Client.PlayAudioToMember(conference.Name, member, "http://funny-stuff.audio4fun.com/download/audioclips/159.mp3");

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Start_Recording_Conference()
        {
            var conference = Client.GetConference(ConferenceName);
            var status = Client.StartRecordingConference(conference.Conferences[0].Name);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Stop_Recording_Conference()
        {
            var conference = Client.GetConference(ConferenceName);
            var status = Client.StopRecordingConference(conference.Conferences[0].Name);

            Assert.NotNull(status);
        }

    }
}

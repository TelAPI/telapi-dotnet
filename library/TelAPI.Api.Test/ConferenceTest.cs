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
            var conference = _client.GetConference("test");

            Assert.NotNull(conference);
        }

        [Fact]
        public void Can_I_Get_Conference_List()
        {
            var conferences = _client.GetConferences();

            Assert.NotNull(conferences);
        }

        [Fact]
        public void Can_I_Mute_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var receivedConference = _client.MuteMember(conference.Name, members);

            Assert.NotNull(receivedConference);
            Assert.Equal(conference.Name, receivedConference.Name);
        }

        [Fact]
        public void Can_I_Unmute_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var receivedConference = _client.UnmuteMember(conference.Name, members);

            Assert.NotNull(receivedConference);
            Assert.Equal(conference.Name, receivedConference.Name);
        }

        [Fact]
        public void Can_I_Deaf_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var receivedConference = _client.DeafMember(conference.Name, members);

            Assert.NotNull(receivedConference);
            Assert.Equal(conference.Name, receivedConference.Name);
        }

        [Fact]
        public void Can_I_Undeaf_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var receivedConference = _client.UndeafMember(conference.Name, members);

            Assert.NotNull(receivedConference);
            Assert.Equal(conference.Name, receivedConference.Name);
        }

        [Fact]
        public void Can_I_Hangup_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var receivedConference = _client.HangupMember(conference.Name, members);

            Assert.NotNull(receivedConference);
            Assert.Equal(conference.Name, receivedConference.Name);
        }

        [Fact]
        public void Can_I_Kick_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var receivedConference = _client.KickMember(conference.Name, members);

            Assert.NotNull(receivedConference);
            Assert.Equal(conference.Name, receivedConference.Name);
        }

        [Fact]
        public void Can_I_Speak_Text_To_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var response = _client.SpeakTextToMember(conference.Name, members, "test it is");

            Assert.NotNull(response);            
        }

        [Fact]
        public void Can_I_Play_Audio_To_Member()
        {
            var conference = _client.GetConference("test");
            var member = conference.Members[0];
            var members = new List<string>();
            members.Add(member.Id);

            var response = _client.PlayAudioToMember(conference.Name, members, "http://www.fake.com");

            Assert.NotNull(response);
        }

        [Fact]
        public void Can_I_Start_Recording_Conference()
        {
            var conference = _client.GetConference("test");
            var response = _client.StartRecordingConference(conference.Name);

            Assert.NotNull(response);
        }

        [Fact]
        public void Can_I_Stop_Recording_Conference()
        {
            var conference = _client.GetConference("test");
            var response = _client.StopRecordingConference(conference.Name);

            Assert.NotNull(response);
        }

    }
}

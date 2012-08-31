using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class ConferenceTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Conference()
        {
            var conference = Client.GetConference(ConferenceSid);
            Assert.NotNull(conference);

            Console.WriteLine("{0}", conference.Name);
        }

        [Fact]
        public void Can_I_Get_Conference_List()
        {
            var conferences = Client.GetConferences();
            Assert.NotNull(conferences);

            foreach (var c in conferences.Conferences)
            {
                Console.WriteLine("{0}", c.Name);
            }
        }

        [Fact]
        public void Can_I_Mute_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.MuteMember(conference.Sid, member);

            Console.WriteLine("{0}", conference.Name);
            Console.WriteLine("{0}", status.DateUpdated);

            Assert.NotNull(status);
           
        }

        [Fact]
        public void Can_I_Unmute_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.UnmuteMember(conference.Sid, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Deaf_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.DeafMember(conference.Sid, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Undeaf_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.UndeafMember(conference.Sid, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Hangup_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.HangupMember(conference.Sid, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Kick_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.KickMember(conference.Sid, member);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Play_Audio_To_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.PlayAudioToMember(conference.Sid, member, "http://funny-stuff.audio4fun.com/download/audioclips/159.mp3");

            Assert.NotNull(status);
        }

        /*

        [Fact]
        public void Can_I_Speak_Text_To_Member()
        {
            var conference = Client.GetConference(ConferenceSid);
            var member = conference.Members[0];

            var status = Client.SpeakTextToMember(conference.Sid, member, "hello world. I'm conference robot");

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Start_Recording_Conference()
        {
            var conference = Client.GetConference(ConferenceName);
            var status = Client.StartRecordingConference(conference.Name);

            Assert.NotNull(status);
        }

        [Fact]
        public void Can_I_Stop_Recording_Conference()
        {
            var conference = Client.GetConference(ConferenceName);
            var status = Client.StopRecordingConference(conference.Name);

            Assert.NotNull(status);
        }
         
        */

    }
}

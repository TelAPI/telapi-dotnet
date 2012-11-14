using YAXLib;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Conference")]
    public class Conference : DialElement
    {
        [YAXValueForClass]
        public string ConferenceName { get; set; }

        [YAXSerializeAs("muted")]
        [YAXAttributeForClass]
        public string Muted { get; set; }

        [YAXSerializeAs("beep")]
        [YAXAttributeForClass]
        public string Beep { get; set; }

        [YAXSerializeAs("startConferenceOnEnter")]
        [YAXAttributeForClass]
        public string StartConferenceOnEnter { get; set; }

        [YAXSerializeAs("endConferenceOnExit")]
        [YAXAttributeForClass]
        public string EndConferenceOnExit { get; set; }

        [YAXSerializeAs("maxParticipants")]
        [YAXAttributeForClass]
        public string MaxParticipants { get; set; }

        [YAXSerializeAs("waitUrl")]
        [YAXAttributeForClass]
        public string WaitUrl { get; set; }

        [YAXSerializeAs("waitMethod")]
        [YAXAttributeForClass]
        public string WaitMethod { get; set; }

        [YAXSerializeAs("hangupOnStar")]
        [YAXAttributeForClass]
        public string HangupOnStar { get; set; }

        [YAXSerializeAs("callbackUrl")]
        [YAXAttributeForClass]
        public string CallbackUrl { get; set; }

        [YAXSerializeAs("callbackMethod")]
        [YAXAttributeForClass]
        public string CallbackMethod { get; set; }

        [YAXSerializeAs("waitSound")]
        [YAXAttributeForClass]
        public string WaitSound { get; set; }

        [YAXSerializeAs("waitSoundMethod")]
        [YAXAttributeForClass]
        public string WaitSoundMethod { get; set; }

        [YAXSerializeAs("digitsMatch")]
        [YAXAttributeForClass]
        public string DigitsMatch { get; set; }

        [YAXSerializeAs("stayAlone")]
        [YAXAttributeForClass]
        public string StayAlone { get; set; }

        public Conference()
        {

        }

        /// <summary>
        /// Conference element allows the ongoing call to connect to a conference room.
        /// </summary>
        /// <param name="conferenceName">Name of the conference</param>
        /// <returns></returns>
        public static Conference Create(string conferenceName)
        {
            var conference = new Conference();
            conference.ConferenceName = conferenceName;

            return conference;
        }

        /// <summary>
        /// Conference element allows the ongoing call to connect to a conference room.
        /// </summary>
        /// <param name="conferenceName">Name of the conference</param>
        /// <param name="muted">Boolean value specifying if the conference should be muted.</param>
        /// <param name="beep">Boolean value specifying if a beep should play upon entrance to conference.</param>
        /// <param name="startConferenceOnEnter">Boolean value specifying if conference should begin upon entrance.</param>
        /// <param name="endConferenceOnExit">Boolean value specifying if conference should begin upon exit.</param>
        /// <param name="maxParticipants">The maximum number of participants allowed in the conference call.</param>
        /// <param name="waitUrl">URL conference participants can be sent to while they wait for entrance into the conference.</param>
        /// <param name="waitMethod">Method used to request waitUrl.</param>
        /// <param name="hangupOnStar">Boolean value specifying if pressing * should end the conference.</param>
        /// <param name="callbackUrl">URL where some parameters specific to <Conference> will be sent once it is completed.</param>
        /// <param name="callbackMethod">Method used to request the callback URL.</param>
        /// <param name="waitSound">URL to sound that can be played while waiting to enter the conference.</param>
        /// <param name="waitSoundMethod">Method used to request the waitsound URL.</param>
        /// <param name="digitsMatch">Specifies digits that TelAPI should listen for and send to the callbackUrl if a caller inputs them. Seperate additional digits or digit patterns with a comma.</param>
        /// <param name="stayAlone">Boolean value specifying if the caller should stay alone in the conference call.</param>
        /// <returns></returns>
        public static Conference Create(string conferenceName, bool? muted, bool? beep, bool? startConferenceOnEnter, bool? endConferenceOnExit, long? maxParticipants, string waitUrl, HttpMethod? waitMethod, bool? hangupOnStar, string callbackUrl, HttpMethod? callbackMethod, string waitSound, HttpMethod? waitSoundMethod, string digitsMatch, bool? stayAlone)
        {
            Conference conference = new Conference();

            conference.ConferenceName = conferenceName;
            conference.Muted = muted == null ? null : muted.ToString();
            conference.Beep = beep == null ? null : beep.ToString();
            conference.StartConferenceOnEnter = startConferenceOnEnter == null ? null : startConferenceOnEnter.ToString();
            conference.EndConferenceOnExit = endConferenceOnExit == null ? null : endConferenceOnExit.ToString();
            conference.MaxParticipants = maxParticipants == null ? null : maxParticipants.ToString();
            conference.WaitUrl = waitUrl;
            conference.WaitMethod = waitMethod == null ? null : waitMethod.ToString();
            conference.HangupOnStar = hangupOnStar == null ? null : hangupOnStar.ToString();
            conference.CallbackUrl = callbackUrl;
            conference.CallbackMethod = callbackMethod == null ? null : callbackMethod.ToString();
            conference.WaitSound = waitSound;
            conference.WaitSoundMethod = waitSoundMethod == null ? null : waitSoundMethod.ToString();
            conference.DigitsMatch = digitsMatch;
            conference.StayAlone = stayAlone == null ? null : stayAlone.ToString();

            return conference;
        }
    }
}

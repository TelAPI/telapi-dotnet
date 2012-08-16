using System;
using System.Collections.Generic;
using YAXLib;
using TelAPI.InboundXML.Enum;
using TelAPI.InboundXML.Option;


namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Dial")]
    public class Dial : ELement
    {
        [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement)]
        public List<DialElement> Elements { get; set; }

        [YAXValueForClass]
        [YAXSerializeAs("number")]
        public string Value { get; set;}

        [YAXAttributeForClass]
        [YAXSerializeAs("action")]
        public string Action { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("method")]
        public string Method { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("timeout")]
        public string Timeout { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("hangupOnStar")]
        public string HangupOnStar { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("timeLimit")]
        public string TimeLimit { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("callerId")]
        public string CallerId { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("hideCallerId")]
        public string HideCallerId { get; set; }
        
        [YAXAttributeForClass]
        [YAXSerializeAs("dialMusic")]
        public string DialMusic { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("callbackUrl")]
        public string CallbackUrl { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("callbackMethod")]
        public string CallbackMethod { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("confirmSound")]
        public string ConfirmSound { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("digitsMatch")]
        public string DigitsMatch { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("straightToVm")]
        public string StraightToVm { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("heartbeatUrl")]
        public string HeartbeatUrl { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("heartbeatMethod")]
        public string HeartbeatMethod { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("forwardedFrom")]
        public string ForwardedFrom { get; set; }

        public Dial()
        {
            Elements = new List<DialElement>();
        }

        /// <summary>
        /// The Dial element starts an outgoing dial from the current call.
        /// </summary>
        /// <param name="number">Number to dial</param>
        /// <returns></returns>
        public static Dial Create(string number)
        {
            var dial = new Dial();
            dial.Value = number;

            return dial;
        }

        public static Dial Create(DialOptions dialOptions)
        {
            return Create(dialOptions.Value,
                dialOptions.Action,
                dialOptions.Method,
                dialOptions.Timeout,
                dialOptions.HangupOnStar,
                dialOptions.Timelimit,
                dialOptions.CallerId,
                dialOptions.HideCallerId,
                dialOptions.DialMusic,
                dialOptions.CallbackUrl,
                dialOptions.CallbackMethod,
                dialOptions.ConfirmSound,
                dialOptions.DigitsMatch,
                dialOptions.StraightToVm,
                dialOptions.HeartbeatUrl,
                dialOptions.HeartbeatMethod,
                dialOptions.ForwardedFrom);
        }
                

        /// <summary>
        /// The Dial element starts an outgoing dial from the current call.
        /// </summary>
        /// <param name="number">Number to dial</param>
        /// <param name="action">URL where some parameters specific to <Dial> will be sent for further processing. The calling party can be redirected here upon the hangup of the B leg caller.</param>
        /// <param name="method">Method used to request the action URL.</param>
        /// <param name="timeout">The number of seconds calls made with <Dial> are allowed silence before ending.</param>
        /// <param name="hangupOnStar">Boolean value specifying if pressing * should end the dial.</param>
        /// <param name="timeLimit">The duration in seconds a call made through <Dial> should occur for before ending.</param>
        /// <param name="callerId">Number to display as calling. Defaults to the ID of phone being used.</param>
        /// <param name="hideCallerId">Boolean value specifying if the caller ID should be hidden or not.</param>
        /// <param name="dialMusic">URL containing an audio file that can be played during the dial.</param>
        /// <param name="callbackUrl">URL requested once the dialed call connects.</param>
        /// <param name="callbackMethod">Method used to request the callback URL.</param>
        /// <param name="confirmSound">Boolean value specifying if a sound should play when dial is successful.</param>
        /// <param name="digitsMatch">Specifies digits that TelAPI should listen for and send to the callbackUrl if a caller inputs them. Seperate additional digits or digit patterns with a comma.</param>
        /// <param name="straightToVm">Boolean value specifying if call should be redirected to voicemail imediately.</param>
        /// <param name="heartbeatUrl">A URL TelAPI can request every 60 seconds during the call to notify of elapsed time and pass other general information.</param>
        /// <param name="heartbeatMethod">Method used to request the heartbeat URL.</param>
        /// <param name="forwardedFrom">Specifies the number to list the call as forwarded from.</param>
        /// <returns></returns>
        public static Dial Create(string number, string action, HttpMethod? method, long? timeout, bool? hangupOnStar, long? timeLimit, string callerId, bool? hideCallerId, string dialMusic, string callbackUrl, HttpMethod? callbackMethod, bool? confirmSound, string digitsMatch, bool? straightToVm, string heartbeatUrl, HttpMethod? heartbeatMethod, string forwardedFrom)
        {
            Dial dial = new Dial();

            dial.Value = number;
            dial.Action = action;
            dial.Method = method == null ? null : method.ToString();
            dial.Timeout = timeout == null ? null : timeout.ToString();
            dial.HangupOnStar = hangupOnStar == null ? null : hangupOnStar.ToString();
            dial.TimeLimit = timeLimit == null ? null : timeLimit.ToString();
            dial.CallerId = callerId;
            dial.HideCallerId = hideCallerId == null ? null : hideCallerId.ToString();           
            dial.DialMusic = dialMusic;
            dial.CallbackUrl = callbackUrl;
            dial.CallbackMethod = callbackMethod == null ? null : callbackMethod.ToString();
            dial.ConfirmSound = confirmSound == null ? null : confirmSound.ToString();
            dial.DigitsMatch = digitsMatch;
            dial.StraightToVm = straightToVm == null ? null : straightToVm.ToString();
            dial.HeartbeatUrl = heartbeatUrl;
            dial.HeartbeatMethod = heartbeatMethod == null ? null : heartbeatMethod.ToString();
            dial.ForwardedFrom = forwardedFrom;

            return dial;
        }

        /// <summary>
        /// It can be used to send DTFM tones or redirect to InboundXML
        /// </summary>
        /// <param name="number">Number to send</param>
        /// <param name="sendDigits">Specifies which DTFM tones to play to the called party. w indicates a half second pause.</param>
        /// <param name="url">URL that the called party can be directed to before the call beings.</param>
        /// <param name="callbackMethod">method used to request the url.</param>
        /// <returns></returns>
        public Dial Number(string number, string sendDigits, string url, HttpMethod? callbackMethod)
        {
            var num = Element.Number.Create(number, sendDigits, url, callbackMethod);
            Elements.Add(num);

            return this;
        }

        /// <summary>
        /// The Conference element allows the ongoing call to connect to a conference room.
        /// </summary>
        /// <param name="conferenceName">Name of the conference</param>
        /// <returns></returns>
        public Dial Conference(string conferenceName)
        {
            var conference = Element.Conference.Create(conferenceName);
            Elements.Add(conference);

            return this;
        }

        /// <summary>
        /// The Conference element allows the ongoing call to connect to a conference room.
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
        public Dial Conference(string conferenceName, bool? muted, bool? beep, bool? startConferenceOnEnter, bool? endConferenceOnExit, long? maxParticipants, string waitUrl, HttpMethod? waitMethod, bool? hangupOnStar, string callbackUrl, HttpMethod? callbackMethod, string waitSound, HttpMethod? waitSoundMethod, string digitsMatch, bool? stayAlone)
        {
            var conference = Element.Conference.Create(conferenceName, muted, beep, startConferenceOnEnter, endConferenceOnExit, maxParticipants, waitUrl, waitMethod, hangupOnStar, callbackUrl, callbackMethod, waitSound, waitSoundMethod, digitsMatch, stayAlone);
            Elements.Add(conference);

            return this;
        }

        /// <summary>
        /// Used to call to sip addresses
        /// </summary>
        /// <param name="sipAddress">Address of the SIP</param>
        /// <returns></returns>
        public Dial Sip(string sipAddress)
        {
            var sip = Element.Sip.Create(sipAddress, null, null, null);
            Elements.Add(sip);

            return this;
        }
                
        /// <summary>
        /// Used to call to sip addresses
        /// </summary>
        /// <param name="sipAddress">Address of the SIP</param>
        /// <param name="sendDigits">Specifies which DTFM tones to play to the called party. w indicates a half second pause.</param>
        /// <param name="url">URL that the called party can be directed to before the call beings.</param>
        /// <param name="method">method used to request the url.</param>
        /// <returns></returns>
        public Dial Sip(string sipAddress, string sendDigits, string url, HttpMethod? method)
        {
            var s = Element.Sip.Create(sipAddress, sendDigits, url, method);
            Elements.Add(s);

            return this;
        }
    }
}

using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Option
{
    /// <summary>
    /// Class that contains all possible Dial options
    /// </summary>
    public class DialOptions
    {              
        /// <summary>
        /// Number to dial
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// URL where some parameters specific to <Dial> will be sent for further processing. The calling party can be redirected here upon the hangup of the B leg caller.
        /// </summary>
        public string Action { get; set; }
        
        /// <summary>
        /// Method used to request the action URL.
        /// </summary>
        public HttpMethod? Method { get; set; }
        
        /// <summary>
        /// The number of seconds calls made with <Dial> are allowed silence before ending.
        /// </summary>
        public long? Timeout { get; set; }

        /// <summary>
        /// Boolean value specifying if pressing * should end the dial.
        /// </summary>
        public bool HangupOnStar { get; set; }

        /// <summary>
        /// The duration in seconds a call made through <Dial> should occur for before ending.
        /// </summary>
        public long? Timelimit { get; set; }

        /// <summary>
        /// Number to display as calling. Defaults to the ID of phone being used.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        /// Boolean value specifying if the caller ID should be hidden or not.
        /// </summary>
        public bool? HideCallerId { get; set; }

        /// <summary>
        /// URL containing an audio file that can be played during the dial.
        /// </summary>
        public string DialMusic { get; set; }

        /// <summary>
        /// URL requested once the dialed call connects.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Method used to request the callback URL.
        /// </summary>
        public HttpMethod? CallbackMethod { get; set; }

        /// <summary>
        /// Boolean value specifying if a sound should play when dial is successful.
        /// </summary>
        public bool? ConfirmSound { get; set; }

        /// <summary>
        /// Specifies digits that TelAPI should listen for and send to the callbackUrl if a caller inputs them. Seperate additional digits or digit patterns with a comma.
        /// </summary>
        public string DigitsMatch { get; set; }

        /// <summary>
        /// Boolean value specifying if call should be redirected to voicemail imediately.
        /// </summary>
        public bool? StraightToVm { get; set; }

        /// <summary>
        /// A URL TelAPI can request every 60 seconds during the call to notify of elapsed time and pass other general information.
        /// </summary>
        public string HeartbeatUrl { get; set; }

        /// <summary>
        /// Method used to request the heartbeat URL.
        /// </summary>
        public HttpMethod? HeartbeatMethod { get; set; }

        /// <summary>
        /// Specifies the number to list the call as forwarded from.
        /// </summary>
        public string ForwardedFrom { get; set; }
    }
}

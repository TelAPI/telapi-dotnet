using System;
using System.Xml.Linq;
using System.Collections.Generic;
using YAXLib;

using TelAPI.InboundXML.Enum;
using TelAPI.InboundXML.Element;


namespace TelAPI.InboundXML
{    
    public class Response
    {    
        [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement)]
        public List<ELement> Elements { get; set; }             

        public Response()
        {                       
            Elements = new List<ELement>();
        }

        /// <summary>
        /// The Play element plays an mp3 file for the caller.
        /// </summary>
        /// <param name="resource">Resource URL of audio file to play</param>        
        /// <returns></returns>
        public Response Play(string resource)
        {
            Elements.Add(Element.Play.Create(resource, null));
            return this;
        }

        /// <summary>
        /// The Play element plays an mp3 file for the caller.
        /// </summary>
        /// <param name="resource">Resource URL of audio file to play</param>
        /// <param name="loop">The amount of times the PlayW should be repeated. 0 indicates an infinite loop.</param>
        /// <returns></returns>
        public Response Play(string resource, long loop)
        {
            Elements.Add(Element.Play.Create(resource, loop));
            return this;
        }

        /// <summary>
        /// The Say element reads text to the caller using a text-to-speech engine. 
        /// </summary>
        /// <param name="text">Text to speech</param>        
        /// <returns></returns>
        public Response Say(string text)
        {
            Elements.Add(Element.Say.Create(text, null, null));
            return this;
        }

        /// <summary>
        /// The Say element reads text to the caller using a text-to-speech engine. 
        /// </summary>
        /// <param name="text">Text to speech</param>
        /// <param name="voice">The type of voice that will read the text to caller.</param>
        /// <param name="loop">The amount of times the spoken text should be repeated. 0 indicates an infinite loop.</param>
        /// <returns></returns>
        public Response Say(string text, Voice? voice, long? loop)
        {
            Elements.Add(Element.Say.Create(text, voice, loop));
            return this;
        }

        /// <summary>
        /// The Record element is used to record audio during a call.
        /// </summary>
        /// <param name="action">URL where some parameters specific to Record will be sent for further processing.</param>
        /// <returns></returns>
        public Response Record(string action)
        {
            Elements.Add(Element.Record.Create(action));
            return this;
        }

        /// <summary>
        /// The Record element is used to record audio during a call.
        /// </summary>
        /// <param name="action">URL where some parameters specific to Record will be sent for further processing.</param>
        /// <param name="method">Specifies the method to use when requesting the action or transcribeCallback URL.</param>
        /// <param name="timeout">The number of seconds Record should wait during silence before ending.</param>
        /// <param name="finishOnKey">The key a caller can press to end the Record.</param>
        /// <param name="maxLength">The maximum length in seconds a recording should be.</param>
        /// <param name="transcribe">Boolean value specifying if the recording should be transcribed.</param>
        /// <param name="transcribeCallback">URL where the recording transcription will be sent.</param>
        /// <param name="playBeep">Boolean value specifying if a beep should be played when the recording begins.</param>
        /// <param name="bothLegs">Boolean value specifying if both call legs should be recorded.</param>
        /// <param name="fileFormat">The recording file format. Can be mp3 or wav. Default is mp3</param>
        /// <returns></returns>
        public Response Record(string action, HttpMethod? method, long? timeout, string finishOnKey, long? maxLength, bool? transcribe, string transcribeCallback, bool? playBeep, bool? bothLegs, RecordingFileFormat? fileFormat)
        {
            Elements.Add(Element.Record.Create(action, method, timeout, finishOnKey, maxLength, transcribe, transcribeCallback, playBeep, bothLegs, fileFormat));
            return this;
        }

        /// <summary>
        /// The Hangup element will hangup the current call.
        /// </summary>
        /// <returns></returns>
        public Response Hangup()
        {
            Elements.Add(Element.Hangup.Create(null));
            return this;
        }

        /// <summary>
        /// The Hangup element will hangup the current call.
        /// </summary>
        /// <param name="schedule">Specifies in seconds when a hangup should occur during a call.</param>
        /// <returns></returns>
        public Response Hangup(long schedule)
        {
            Elements.Add(Element.Hangup.Create(schedule));
            return this;
        }

        /// <summary>
        /// The Redirect element directs the call to another InboundXML document.
        /// </summary>
        /// <param name="url">URL where redirection will occur</param>
        /// <returns></returns>
        public Response Redirect(string url)
        {
            Elements.Add(Element.Redirect.Create(url, null));
            return this;
        }

        /// <summary>
        /// The Redirect element directs the call to another InboundXML document.
        /// </summary>
        /// <param name="url">URL where redirection will occur</param>
        /// <param name="method">Method used to request the InboundXML doucment the call is being redirected to.</param>
        /// <returns></returns>
        public Response Redirect(string url, HttpMethod method)
        {
            Elements.Add(Element.Redirect.Create(url, method));
            return this;
        }

        /// <summary>
        /// The Reject element will reject an incoming call. 
        /// </summary>
        /// <returns></returns>
        public Response Reject()
        {
            Elements.Add(Element.Reject.Create(null));
            return this;
        }

        /// <summary>
        /// The Reject element will reject an incoming call.
        /// </summary>
        /// <param name="reason">The reason to list as why the call was rejected.</param>
        /// <returns></returns>
        public Response Reject(RejectReason reason)
        {
            Elements.Add(Element.Reject.Create(reason));
            return this;
        }

        /// <summary>
        /// The Pause element will pause the call, holding for the number of seconds set by the length attribute.
        /// </summary>
        /// <returns></returns>
        public Response Pause()
        {
            Elements.Add(Element.Pause.Create(null));
            return this;
        }

        /// <summary>
        /// The Pause element will pause the call, holding for the number of seconds set by the length attribute.
        /// </summary>
        /// <param name="length">The length in seconds the pause should be.</param>
        /// <returns></returns>
        public Response Pause(long length)
        {
            Elements.Add(Element.Pause.Create(length));
            return this;
        }

        /// <summary>
        /// The Sms element can be used to send SMS messages.
        /// </summary>
        /// <param name="text">Message text. Max 160 characters</param>
        /// <param name="to">The phone number that will receive the SMS message.</param>
        /// <param name="from">The number that will display as sending the SMS message.</param>
        /// <returns></returns>
        public Response Sms(string text, string to, string from)
        {
            Elements.Add(Element.Sms.Create(text, to, from, null, null, null));
            return this;
        }

        /// <summary>
        /// The Sms element can be used to send SMS messages.
        /// </summary>
        /// <param name="text">Message text. Max 160 characters</param>
        /// <param name="to">The phone number that will receive the SMS message.</param>
        /// <param name="from">The number that will display as sending the SMS message.</param>
        /// <param name="action">URL where paramaters specific to <Sms> are sent.</param>
        /// <param name="method">Method used to request the action URL.</param>
        /// <param name="statusCallback">URL where the status of the SMS can be sent.</param>
        /// <returns></returns>
        public Response Sms(string text, string to, string from, string action, HttpMethod? method, string statusCallback)
        {
            Elements.Add(Element.Sms.Create(text, to, from, action, method, statusCallback));
            return this;
        }

        /// <summary>
        /// The Dial element starts an outgoing dial from the current call.
        /// </summary>
        /// <param name="dial">Dial element</param>
        /// <returns></returns>
        public Response Dial(Dial dial)
        {
            Elements.Add(dial);
            return this;
        }

        /// <summary>
        /// The Gather element allows callers to input digits to the call using their keypads which are then sent via POST or GET to a URL for further processing. 
        /// </summary>
        /// <param name="gather">Gather object</param>
        /// <returns></returns>
        public Response Gather(Gather gather)
        {
            Elements.Add(gather);
            return this;
        }

        /// <summary>
        /// The GetSpeech element is used to translate a callers voice into text.
        /// </summary>
        /// <param name="speech">GetSpeech object.</param>
        /// <returns></returns>
        public Response GetSpeech(GetSpeech speech)
        {
            Elements.Add(speech);
            return this;
        }      
                
        /// <summary>
        /// Create valid TelApi XML response
        /// </summary>
        /// <returns></returns>
        public string CreateXml()
        {
            var serializer = new YAXSerializer(typeof(Response), YAXExceptionHandlingPolicies.ThrowErrorsOnly, YAXExceptionTypes.Error, YAXSerializationOptions.DontSerializeNullObjects);
            var result = serializer.SerializeToXDocument(this);

            return ModifyXML(result);
        }

        #region XML helper methods
        
        /// <summary>
        /// Remove Yaxlib namespace and attributes from XML tree which were generated during XML serialization
        /// </summary>
        /// <param name="result">Generated XDocument</param>
        /// <returns></returns>
        private static string ModifyXML(XDocument result)
        {
            foreach (var e in result.Descendants())
            {
                foreach (var a in e.Attributes())
                {
                    if (a.Name.LocalName == "realtype" || a.Name.LocalName == "yaxlib")
                    {
                        a.Remove();
                    }
                }
            }

            return result.ToString();
        }  
        
        #endregion
    }
}

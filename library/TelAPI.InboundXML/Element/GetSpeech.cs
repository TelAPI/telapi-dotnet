using System;
using System.Collections.Generic;
using YAXLib;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("GetSpeech")]
    public class GetSpeech : ELement
    {
        [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement)]
        public List<GetSpeechElement> Elements { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("grammar")]
        public string Grammar { get; set; }
        
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
        [YAXSerializeAs("playBeep")]
        public string PlayBeep { get; set; }        

        public GetSpeech()
        {
            Elements = new List<GetSpeechElement>();
        }

        /// <summary>
        /// The GetSpeech element is used to translate a callers voice into text.
        /// </summary>
        /// <param name="grammar">An XML file defining acceptable words and phrases that a user might say during the call.</param>
        /// <param name="action">A URL where the converted voice text will be forwarded.</param>
        /// <returns></returns>
        public static GetSpeech Create(string grammar, string action)
        {
            var speech = new GetSpeech();
            speech.Grammar = grammar;
            speech.Action = action;

            return speech;
        }

        /// <summary>
        /// The GetSpeech element is used to translate a callers voice into text.
        /// </summary>
        /// <param name="grammar">An XML file defining acceptable words and phrases that a user might say during the call.</param>
        /// <param name="action">A URL where the converted voice text will be forwarded.</param>
        /// <param name="method">Method used to request the action URL.</param>
        /// <param name="timeout">Amount of seconds GetSpeech should wait in silence before requesting the action URL.</param>
        /// <param name="playBeep">Specifies if a beep should playback to the caller when GetSpeech begins.</param>
        /// <returns></returns>
        public static GetSpeech Create(string grammar, string action, HttpMethod? method, long? timeout, bool? playBeep)
        {
            var speech = new GetSpeech();

            speech.Grammar = grammar;
            speech.Action = action;
            speech.Method = method == null ? null : method.ToString();
            speech.Timeout = timeout == null ? null : timeout.ToString();            
            speech.PlayBeep = playBeep == null ? null : playBeep.ToString().ToLower();

            return speech;
        }

        /// <summary>
        /// The Play element plays an mp3 file for the caller
        /// </summary>
        /// <param name="resource">Url of the mp3 audio</param>
        /// <param name="loop">The amount of times the Play should be repeated. 0 indicates an infinite loop.</param>
        /// <returns></returns>
        public GetSpeech Play(string resource, long? loop)
        {
            Elements.Add(Element.Play.Create(resource, loop));
            return this;
        }

        /// <summary>
        /// The Say element reads text to the caller using a text-to-speech engine. 
        /// </summary>
        /// <param name="text">Text to say</param>
        /// <param name="voice">The type of voice that will read the text to caller.</param>
        /// <param name="loop">The amount of times the spoken text should be repeated. 0 indicates an infinite loop.</param>
        /// <returns></returns>
        public GetSpeech Say(string text, Voice? voice, long? loop)
        {
            Elements.Add(Element.Say.Create(text, voice, loop));
            return this;
        }

        /// <summary>
        /// The Pause element will pause the call, holding for the number of seconds set by the length attribute.
        /// </summary>
        /// <param name="length">The length in seconds the pause should be.</param>
        /// <returns></returns>
        public GetSpeech Pause(long length)
        {
            Elements.Add(Element.Pause.Create(length));
            return this;
        }

        /// <summary>
        /// The Pause element will pause the call
        /// </summary>
        /// <returns></returns>
        public GetSpeech Pause()
        {
            Elements.Add(Element.Pause.Create(null));
            return this;
        }
    }
}

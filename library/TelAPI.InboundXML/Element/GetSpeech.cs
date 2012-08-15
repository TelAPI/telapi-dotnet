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

        public static GetSpeech Create(string grammar, string action)
        {
            var speech = new GetSpeech();
            speech.Grammar = grammar;
            speech.Action = action;

            return speech;
        }

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

        public GetSpeech Play(string resource, long? loop)
        {
            Elements.Add(Element.Play.Create(resource, loop));
            return this;
        }

        public GetSpeech Say(string text, Voice? voice, long? loop)
        {
            Elements.Add(Element.Say.Create(text, voice, loop));
            return this;
        }

        public GetSpeech Pause(long length)
        {
            Elements.Add(Element.Pause.Create(length));
            return this;
        }

        public GetSpeech Pause()
        {
            Elements.Add(Element.Pause.Create(null));
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using YAXLib;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Gather")]
    public class Gather : ELement
    {
        [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement)]
        public List<GatherElement> Elements { get; set; }

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
        [YAXSerializeAs("finishOnKey")]
        public string FinishOnKey { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("numDigits")]
        public string NumDigits { get; set; }

        public Gather()
        {
            Elements = new List<GatherElement>();
        }

        public static Gather Create(string action)
        {
            var gather = new Gather();
            gather.Action = action;

            return gather;
        }

        public static Gather Create(string action, HttpMethod? method, long? timeout, string finishOnKey, long? numDigits)
        {
            Gather gather = new Gather();

            gather.Action = action;
            gather.Method = method == null ? null : method.ToString();
            gather.Timeout = timeout == null ? null : timeout.ToString();
            gather.FinishOnKey = finishOnKey;
            gather.NumDigits = numDigits == null ? null : timeout.ToString();

            return gather;
        }

        public Gather Play(string resource, long? loop)
        {
            Elements.Add(Element.Play.Create(resource, loop));
            return this;
        }

        public Gather Say(string text, Voice? voice, long? loop)
        {
            Elements.Add(Element.Say.Create(text, voice, loop));
            return this;
        }

        public Gather Pause(long length)
        {
            Elements.Add(Element.Pause.Create(length));
            return this;
        }

        public Gather Pause()
        {
            Elements.Add(Element.Pause.Create(null));
            return this;
        }
    }
}

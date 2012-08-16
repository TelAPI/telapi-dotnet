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

        /// <summary>
        /// The Gather element allows callers to input digits to the call using their keypads which are then sent via POST or GET to a URL for further processing. 
        /// </summary>
        /// <param name="action">URL where data will be sent</param>
        /// <returns></returns>
        public static Gather Create(string action)
        {
            var gather = new Gather();
            gather.Action = action;

            return gather;
        }

        /// <summary>
        /// The Gather element allows callers to input digits to the call using their keypads which are then sent via POST or GET to a URL for further processing. 
        /// </summary>
        /// <param name="action">URL where the gathered digits will be sent for further processing.</param>
        /// <param name="method">Method used to request the action URL.</param>
        /// <param name="timeout">The number of seconds Gather should wait for digits to be entered before requesting the action URL. Timeout resets with each new digit input.</param>
        /// <param name="finishOnKey">The key a caller can press to end the Gather.</param>
        /// <param name="numDigits">The maximum number of digits to Gather.</param>
        /// <returns></returns>
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

        /// <summary>
        /// The Play element plays an mp3 file for the caller
        /// </summary>
        /// <param name="resource">Url of the mp3 audio</param>
        /// <param name="loop">The amount of times the Play should be repeated. 0 indicates an infinite loop.</param>
        /// <returns></returns>
        public Gather Play(string resource, long? loop)
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
        public Gather Say(string text, Voice? voice, long? loop)
        {
            Elements.Add(Element.Say.Create(text, voice, loop));
            return this;
        }

        /// <summary>
        /// The Pause element will pause the call, holding for the number of seconds set by the length attribute.
        /// </summary>
        /// <param name="length">The length in seconds the pause should be.</param>
        /// <returns></returns>
        public Gather Pause(long length)
        {
            Elements.Add(Element.Pause.Create(length));
            return this;
        }

        /// <summary>
        /// The Pause element will pause the call
        /// </summary>
        /// <returns></returns>
        public Gather Pause()
        {
            Elements.Add(Element.Pause.Create(null));
            return this;
        }
    }
}

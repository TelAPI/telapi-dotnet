using System;
using System.Collections.Generic;
using YAXLib;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Play")]
    public class Play : ELement, GatherElement, GetSpeechElement
    {
        [YAXValueForClass]        
        public string Resource { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("loop")]
        public string Loop { get; set; }

        public Play()
        {

        }
      
        public static Play Create(string resource, long? loop)
        {
            var play = new Play();

            play.Resource = resource;
            play.Loop = loop == null ? null : loop.ToString();

            return play;
        }
    }
}

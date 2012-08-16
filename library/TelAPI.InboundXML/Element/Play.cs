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
      
        /// <summary>
        /// The Play element plays an mp3 file for the caller.
        /// </summary>
        /// <param name="resource">Url of mp3 audio</param>
        /// <param name="loop">The amount of times the Play should be repeated. 0 indicates an infinite loop.</param>
        /// <returns></returns>
        public static Play Create(string resource, long? loop)
        {
            var play = new Play();

            play.Resource = resource;
            play.Loop = loop == null ? null : loop.ToString();

            return play;
        }
    }
}

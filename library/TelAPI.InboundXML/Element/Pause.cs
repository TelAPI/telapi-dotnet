using System;
using System.Collections.Generic;
using YAXLib;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Pause")]
    public class Pause : ELement, GatherElement, GetSpeechElement
    {
        [YAXAttributeForClass]
        [YAXSerializeAs("length")]
        public string Length { get; set; }

        public Pause()
        {

        }        

        /// <summary>
        /// The Pause element will pause the call, holding for the number of seconds set by the length attribute.
        /// </summary>
        /// <param name="length">The length in seconds the pause should be.</param>
        /// <returns></returns>
        public static Pause Create(long? length)
        {
            var pause = new Pause();
            pause.Length = length == null ? null : length.ToString();

            return pause;
        }     
    }
}

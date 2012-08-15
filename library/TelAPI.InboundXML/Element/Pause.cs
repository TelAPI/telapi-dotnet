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

        public static Pause Create(long? length)
        {
            var pause = new Pause();
            pause.Length = length == null ? null : length.ToString();

            return pause;
        }     
    }
}

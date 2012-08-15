using System;
using System.Xml.Serialization;
using YAXLib;

using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Say")]
    public class Say : ELement, GatherElement, GetSpeechElement
    {
        [YAXValueForClass]
        public string Text { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("loop")]
        public string Loop { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("voice")]
        public string Voice { get; set; }
                
        public Say()
        {
            
        }               

        public static Say Create(string text, Voice? voice, long? loop)
        {
            var say = new Say();   
         
            say.Text = text;
            say.Loop = loop == null ? null : loop.ToString();
            say.Voice = voice == null ? null : voice.ToString();

            return say;
        }
    }
}

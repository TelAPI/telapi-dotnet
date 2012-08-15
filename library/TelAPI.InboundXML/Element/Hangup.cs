using System;
using System.Collections.Generic;
using YAXLib;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Hangup")]
    public class Hangup : ELement
    {
        [YAXAttributeForClass]
        [YAXSerializeAs("schedule")]
        public string Schedule { get; set; }

        public Hangup()
        {

        }

        public static Hangup Create(long? schedule)
        {
            var hangup = new Hangup();
            hangup.Schedule = schedule == null ? null : schedule.ToString();

            return hangup;
        }
    }
}

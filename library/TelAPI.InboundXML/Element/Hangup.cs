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

        /// <summary>
        /// The Hangup element will hangup the current call.
        /// </summary>
        /// <param name="schedule">Specifies in seconds when a hangup should occur during a call.</param>
        /// <returns></returns>
        public static Hangup Create(long? schedule)
        {
            var hangup = new Hangup();
            hangup.Schedule = schedule == null ? null : schedule.ToString();

            return hangup;
        }
    }
}

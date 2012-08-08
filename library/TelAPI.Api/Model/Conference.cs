using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class Conference : TelAPIBase
    {
        /// <summary>
        /// User generated name of the conference.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An alphanumeric string identifying the account the conference occurred through.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// The number of members that participated in the conference.
        /// </summary>
        public int MemberCount { get; set; }

        //Conference duration in seconds.
        public int RunTime { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// List of members involved in the conference.
        /// </summary>
        public List<Member> Members { get; set; }
    }
}

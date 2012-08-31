using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class Conference : TelAPIBase
    {
        /// <summary>
        /// A 34 long unique conference identifier.
        /// </summary>
        public string Sid { get; set; }

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

        /// <summary>
        /// Conference duration in seconds.
        /// </summary>
        public int RunTime { get; set; }

        /// <summary>
        /// Conference status. Can be 'init', 'in-progress' or 'completed'.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date when conference was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date when conference was updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// List of members involved in the conference.
        /// </summary>
        public List<Member> Members { get; set; }
    }
}

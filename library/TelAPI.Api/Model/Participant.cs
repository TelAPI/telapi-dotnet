using System;

namespace TelAPI
{
    public class Participant : TelAPIBase
    {
        /// <summary>
        /// Call sid
        /// </summary>
        public string CallSid { get; set; }
        
        /// <summary>
        /// Conference sid
        /// </summary>
        public string ConferenceSid { get; set; }
        
        /// <summary>
        /// Account sid
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// Muted
        /// </summary>
        public bool Muted { get; set; }

        /// <summary>
        /// Deaf
        /// </summary>
        public bool Deaf { get; set; }

        /// <summary>
        /// Caller name
        /// </summary>
        public string CallerName { get; set; }

        /// <summary>
        /// Caller number
        /// </summary>
        public string CallerNumber { get; set; }
        
        /// <summary>
        /// Duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Date created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date updated
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

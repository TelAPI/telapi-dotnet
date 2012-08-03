using System;

namespace TelAPI
{
    public class RestException
    {
        /// <summary>
        /// Message status about exception
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed information, if avaliable
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Message about exception
        /// </summary>
        public string Message { get; set; }
    }
}

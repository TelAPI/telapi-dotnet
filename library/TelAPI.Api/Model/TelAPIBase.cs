using System;

namespace TelAPI
{
    /// <summary>
    /// TelAPI base abstract class
    /// </summary>
    public abstract class TelAPIBase
    {
        /// <summary>
        /// Exception information
        /// </summary>
        public RestException RestException { get; set; }
        
        /// <summary>
        /// Uri
        /// </summary>
        public Uri Uri { get; set; }
    }
}

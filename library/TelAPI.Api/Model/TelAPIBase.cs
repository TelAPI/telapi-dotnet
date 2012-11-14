using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "rest_exception")]
        public RestException RestException { get; set; }
        
        /// <summary>
        /// Uri
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public Uri Uri { get; set; }
    }
}

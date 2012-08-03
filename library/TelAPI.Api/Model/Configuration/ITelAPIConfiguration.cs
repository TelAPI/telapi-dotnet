using System;

namespace TelAPI
{
    /// <summary>
    /// Interface for TelAPI configuration
    /// </summary>
    public interface ITelAPIConfiguration
    {
        /// <summary>
        /// TelAPI API version to use when making requests
        /// </summary>
        string ApiVersion { get; set; }
        
        /// <summary>
        /// Base URL of Rest Service
        /// </summary>
        string BaseUrl { get; set; }
        
        /// <summary>
        /// Account Sid
        /// </summary>
        string AccountSid { get; set; }
        
        /// <summary>
        /// Authentication Token
        /// </summary>
        string AuthToken { get; set; }
    }
}

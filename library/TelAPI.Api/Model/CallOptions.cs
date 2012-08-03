using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class CallOptions
    {
        /// <summary>
        /// The number to call.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The number to display as calling.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The URL requested once the call connects. 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Specifies the forwarding number to pass to the receiving carrier.
        /// </summary>
        public string ForwardedFrom { get; set; }

        /// <summary>
        /// Specifies the HTTP method used to request the required URL once call connects.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// URL used if any errors occur during execution of InboundXML or at initial request of the required Url provided with the POST.
        /// </summary>
        public string FallbackUrl { get; set; }

        /// <summary>
        /// Specifies the HTTP method used to request FallbackUrl.
        /// </summary>
        public string FallbackMethod { get; set; }

        /// <summary>
        /// URL that can be requested to receive notification when call has ended.
        /// </summary>
        public string StatusCallback { get; set; }

        /// <summary>
        /// Specifies the HTTP method used to request StatusCallbackUrl.
        /// </summary>
        public string StatusCallbackMethod { get; set; }

        /// <summary>
        /// Dials digits once call connects. Can be used to forward callers to different extensions or numbers.
        /// </summary>
        public string SendDigits { get; set; }

        /// <summary>
        /// Number of seconds call stays on the line while waiting for an answer. The max time limit is 999 and the default limit is 60 seconds but lower times can be set.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// Specifies if the caller id will be hidden.
        /// </summary>
        public bool? HideCallerId { get; set; }
    }
}

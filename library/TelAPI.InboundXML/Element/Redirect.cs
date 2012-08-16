using System;
using System.Collections.Generic;
using YAXLib;

using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Element
{
    [YAXSerializeAs("Redirect")]
    public class Redirect : ELement
    {
        [YAXValueForClass]        
        public string Url { get; set; }

        [YAXAttributeForClass]
        [YAXSerializeAs("method")]
        public string Method { get; set; }

        public Redirect()
        {

        }

        /// <summary>
        /// The Redirect element directs the call to another InboundXML document.
        /// </summary>
        /// <param name="url">Url to another InboundXML document</param>
        /// <param name="method">Method used to request the InboundXML doucment the call is being redirected to.</param>
        /// <returns></returns>
        public static Redirect Create(string url, HttpMethod? method)
        {
            var redirect = new Redirect();

            redirect.Url = url;
            redirect.Method = method == null ? null : method.ToString();

            return redirect;
        }
    }
}

using System;
using System.Collections.Generic;

using TelAPI.InboundXML;
using TelAPI.InboundXML.Enum;
using TelAPI.InboundXML.Element;

namespace TelAPI.InboundXML.Example
{
    class Program
    {
        /// <summary>
        /// Url where Telapi will post data after InboundXML execution
        /// </summary>
        private const string UrlWhereToPost = "http://your-web-page.com";

        /// <summary>
        /// Url of audio resource to play on the call
        /// </summary>
        private const string UrlWhatToPlay = "http://url-of-audio-resource.com";

        /// <summary>
        /// Url of the grammar for GetSpeech()
        /// </summary>
        private const string UrlOfGrammar = "http://url-of-the-grammar.com";
        
        /// <summary>
        /// Phone number for dial while in the call
        /// </summary>
        private const string PhoneNumberToDial = "phone-number-to-dial";
        
        static void Main(string[] args)
        {
            // We need to create Response object and after 
            // that we can call any method that we need

            var response = new Response();

            response.Say("Hello", null, null)
                    .Say("This is automated message", Voice.woman, null)
                    .Say("From now I will record this call", Voice.man, null)
                    .Record(UrlWhereToPost, null, 5, "#", 30, null, null, true, null, null)
                    .Say("I will dial another number now.")
                    .Dial(Dial.Create(PhoneNumberToDial))
                    .Play(UrlWhatToPlay)
                    .GetSpeech(GetSpeech.Create(UrlOfGrammar, UrlWhereToPost).Say("Pausing...", null, null).Pause())                    
                    .Say("I will hangup now. Goodbye!", null, null)
                    .Dial(new Dial().Number("number", "www123", "http://action-url.com", HttpMethod.POST))
                    .Hangup();

            // On the end we need to call CreateXml on Response object
            // so that we can see our generated XML

            Console.WriteLine("{0}", response.CreateXml());
            Console.ReadKey();
        }
    }
}

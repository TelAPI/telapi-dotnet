using System;
using TelAPI;

namespace TelAPI.Api.Test
{
    public class TelAPIBaseTest
    {
        protected TelAPIRestClient Client;

        public const string AccountSid = "ACbf75172498784edc98406f494ec7abec";
        public const string AuthToken = "11e457ff63174f3e94bd6cb9b7812021";

        public const string PhoneNumberFrom = "+12484291605";
        public const string PhoneNumberTo = "+12532697894";
        public const string ConferenceSid = "CF82fba8e04850438fb8c036c6dac2cf01";
        public const string IsoCountryCode = "US";
        public const string TestCountryCode = "RU";
        public const string ActionUrl = "http://some-action-url.com";
        public const string AudioUrl = "http://some-audio-url.com";
        public const string TranscribeAudioUrl = "http://www.fiftiesweb.com/usa/gettysburg-address-sw.mp3";
    

        public TelAPIBaseTest()
        {
            this.Client = new TelAPIRestClient(AccountSid, AuthToken);
        }
    }
}

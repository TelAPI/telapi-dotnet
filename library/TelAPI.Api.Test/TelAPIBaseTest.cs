using System;
using TelAPI;

namespace TelAPI.Api.Test
{
    public class TelAPIBaseTest
    {
        protected TelAPIRestClient Client;

        public const string AccountSid = "your-account-sid";
        public const string AuthToken = "your-auth-token";

        public const string PhoneNumberFrom = "+1234556776";
        public const string PhoneNumberTo = "+1245656566";
        public const string ConferenceSid = "sid";
        public const string RecordingSid = "sid";
        public const string RecordingCallSid = "sid";
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

using System;
using TelAPI;

namespace TelAPI.Api.Test
{
    public class TelAPIBaseTest
    {
        protected TelAPIRestClient Client;

        public const string AccountSid = "your-account-sid";
        public const string AuthToken = "your-auth-token";

        public const string PhoneNumberFrom = "+12432342423";
        public const string PhoneNumberTo = "+1223424243";
        public const string ConferenceSid = "CF6a24d06e8db447c98d7bbc1cbb1806e8";
        public const string RecordingSid = "RE20f5e4f35cc247b088026f72a1b87318";
        public const string RecordingCallSid = "CA8355a41cdf664dcd83afeba0b1274c40";
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

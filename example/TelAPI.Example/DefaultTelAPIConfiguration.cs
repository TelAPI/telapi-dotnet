namespace TelAPI.Example
{
    public class DefaultTelAPIConfiguration : ITelAPIConfiguration
    {

        public string AccountSid { get; set; }
        public string ApiVersion { get; set; }
        public string AuthToken { get; set; }
        public string BaseUrl { get; set; }

        public DefaultTelAPIConfiguration()
        {
            this.AccountSid = "{your-account-sid}";
            this.AuthToken = "{your-auth-token}";
            this.ApiVersion = "2011-07-01";
            this.BaseUrl = "https://api.telapi.com/";
        }
    }
}

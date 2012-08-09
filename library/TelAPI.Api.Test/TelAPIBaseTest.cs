using System;
using TelAPI;

namespace TelAPI.Api.Test
{
    public class TelAPIBaseTest
    {
        protected TelAPIRestClient _client;

        public TelAPIBaseTest()
        {
            this._client = new TelAPIRestClient("your-account-sid", "your-auth-token");
        }
    }
}

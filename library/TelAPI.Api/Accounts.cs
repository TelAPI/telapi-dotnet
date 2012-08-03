using System;
using RestSharp;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Retrive Account details for currently authenticated account. Makes a GET request
        /// </summary>
        /// <returns></returns>
        public Account GetAccount()
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetAccoutUri;

            return Execute<Account>(request);
        }
    }
}

using System.Threading.Tasks;
using SimpleRtRest.RestClient;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Retrive Account details for currently authenticated account. Makes a GET request
        /// </summary>
        /// <returns></returns>
        public async Task<Account> GetAccount()
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetAccoutUri;

            return await Execute<Account>(request);
        }
    }
}

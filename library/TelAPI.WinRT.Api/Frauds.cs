using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Return a list of all fraud control resources associated with a given account
        /// </summary>
        /// <returns></returns>
        public async Task<FraudResult> GetFraudControlResources()
        {
            return await GetFraudControlResources(null, null);
        }

        /// <summary>
        /// Return a list of all fraud control resources associated with a given account
        /// </summary>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public async Task<FraudResult> GetFraudControlResources(int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.FraudControlResourcesUri;

            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return await Execute<FraudResult>(request);
        }

        /// <summary>
        /// Used to authorize destinations for outbound calls and sms messages.
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <returns></returns>
        public async Task<FraudResult> AuthorizeDestination(string countryCode)
        {
            return await AuthorizeDestination(countryCode, null, null, null);
        }

        /// <summary>
        /// Used to authorize destinations for outbound calls and sms messages.
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <param name="mobileBreakout">Mobile breakout status for the destination.</param>
        /// <param name="Landlinebreakout">Landline breakout status for the destination.</param>
        /// <param name="smsEnabled">SMS status for the destination.</param>
        /// <returns></returns>
        public async Task<FraudResult> AuthorizeDestination(string countryCode, bool? mobileBreakout, bool? landlinebreakout, bool? smsEnabled)
        {
            Require.Argument("CountryCode", countryCode);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.FraudAuthorizeDestination;
            request.AddUrlSegment(RequestUriParams.CountryCode, countryCode);

            if (mobileBreakout.HasValue) request.AddParameter("MobileBreakout", mobileBreakout);
            if (landlinebreakout.HasValue) request.AddParameter("LandlineBreakout", landlinebreakout);
            if (smsEnabled.HasValue) request.AddParameter("SmsEnabled", smsEnabled);

            return await Execute<FraudResult>(request);
        }

        /// <summary>
        /// TelAPI will restrict outbound calls and sms messages to blocked destinations. 
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <returns></returns>
        public async Task<FraudResult> BlockDestination(string countryCode)
        {
            return await BlockDestination(countryCode, null, null, null);
        }

        /// <summary>
        /// TelAPI will restrict outbound calls and sms messages to blocked destinations. 
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <param name="mobileBreakout">Mobile breakout status for the destination.</param>
        /// <param name="Landlinebreakout">Landline breakout status for the destination.</param>
        /// <param name="smsEnabled">SMS status for the destination.</param>
        /// <returns></returns>
        public async Task<FraudResult> BlockDestination(string countryCode, bool? mobileBreakout, bool? landlinebreakout, bool? smsEnabled)
        {
            Require.Argument("CountryCode", countryCode);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.FraudBlockDestination;
            request.AddUrlSegment(RequestUriParams.CountryCode, countryCode);

            if (mobileBreakout.HasValue) request.AddParameter("MobileBreakout", mobileBreakout);
            if (landlinebreakout.HasValue) request.AddParameter("LandlineBreakout", landlinebreakout);
            if (smsEnabled.HasValue) request.AddParameter("SmsEnabled", smsEnabled);

            return await Execute<FraudResult>(request);
        }

        /// <summary>
        /// The extend method is provided to extend a destinations authorization expiration by 30 days.
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <returns></returns>
        public async Task<FraudResult> ExtendDestinationAuth(string countryCode)
        {
            return await ExtendDestinationAuth(countryCode, null, null, null);
        }

        /// <summary>
        /// The extend method is provided to extend a destinations authorization expiration by 30 days. 
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <param name="mobileBreakout">Mobile breakout status for the destination.</param>
        /// <param name="Landlinebreakout">Landline breakout status for the destination.</param>
        /// <param name="smsEnabled">SMS status for the destination.</param>
        /// <returns></returns>
        public async Task<FraudResult> ExtendDestinationAuth(string countryCode, bool? mobileBreakout, bool? landlinebreakout, bool? smsEnabled)
        {
            Require.Argument("CountryCode", countryCode);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.FraudExtendDestinationAuthUri;
            request.AddUrlSegment(RequestUriParams.CountryCode, countryCode);

            if (mobileBreakout.HasValue) request.AddParameter("MobileBreakout", mobileBreakout);
            if (landlinebreakout.HasValue) request.AddParameter("LandlineBreakout", landlinebreakout);
            if (smsEnabled.HasValue) request.AddParameter("SmsEnabled", smsEnabled);

            return await Execute<FraudResult>(request);
        }

        /// <summary>
        /// Whitelisting is provided for destinations you wish to permanently authorize.
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <returns></returns>
        public async Task<FraudResult> WhitelistDestination(string countryCode)
        {
            return await WhitelistDestination(countryCode, null, null, null);
        }

        /// <summary>
        /// Whitelisting is provided for destinations you wish to permanently authorize.
        /// </summary>
        /// <param name="countryCode">Two letter country code being whitelisted, authorized or blocked.</param>
        /// <param name="mobileBreakout">Mobile breakout status for the destination.</param>
        /// <param name="Landlinebreakout">Landline breakout status for the destination.</param>
        /// <param name="smsEnabled">SMS status for the destination.</param>
        /// <returns></returns>
        public async Task<FraudResult> WhitelistDestination(string countryCode, bool? mobileBreakout, bool? landlinebreakout, bool? smsEnabled)
        {
            Require.Argument("CountryCode", countryCode);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.FraudWhitelistDestination;
            request.AddUrlSegment(RequestUriParams.CountryCode, countryCode);

            if (mobileBreakout.HasValue) request.AddParameter("MobileBreakout", mobileBreakout);
            if (landlinebreakout.HasValue) request.AddParameter("LandlineBreakout", landlinebreakout);
            if (smsEnabled.HasValue) request.AddParameter("SmsEnabled", smsEnabled);

            return await Execute<FraudResult>(request);
        }
    }
}

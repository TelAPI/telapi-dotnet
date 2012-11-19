using SimpleRtRest.RestClient;
using System;
using System.Threading.Tasks;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// A complete list of usage that has occured through an account can be requested via the REST API.
        /// This list includes every feature of TelAPI an account may use, from inbound/outbound call and SMS messages all the way to Carrier/CNAM lookups.
        /// </summary>
        /// <returns></returns>
        public async Task<UsageResult> GetUsages()
        {
            return await GetUsages(null, null, null, null, null, null);
        }

        /// <summary>
        /// A complete list of usage that has occured through an account can be requested via the REST API.
        /// This list includes every feature of TelAPI an account may use, from inbound/outbound call and SMS messages all the way to Carrier/CNAM lookups.
        /// </summary>
        /// <param name="date">Returns a list of usage for a given date</param>
        /// <returns></returns>
        public async Task<UsageResult> GetUsages(DateTime date)
        {
            return await GetUsages(date.Day, date.Month, date.Year, null, null, null);
        }

        /// <summary>
        /// A complete list of usage that has occured through an account can be requested via the REST API.
        /// This list includes every feature of TelAPI an account may use, from inbound/outbound call and SMS messages all the way to Carrier/CNAM lookups.
        /// </summary>
        /// <param name="product">Returns a list of all usage for a specific "product" or feature of TelAPI.</param>
        /// <returns></returns>
        public async Task<UsageResult> GetUsages(Products product)
        {
            return await GetUsages(null, null, null, null, null, product);
        }

        /// <summary>
        /// A complete list of usage that has occured through an account can be requested via the REST API.
        /// This list includes every feature of TelAPI an account may use, from inbound/outbound call and SMS messages all the way to Carrier/CNAM lookups.
        /// </summary>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public async Task<UsageResult> GetUsages(int? page, int? pageSize)
        {
            return await GetUsages(null, null, null, page, pageSize, null);
        }

        /// <summary>
        /// A complete list of usage that has occured through an account can be requested via the REST API.
        /// This list includes every feature of TelAPI an account may use, from inbound/outbound call and SMS messages all the way to Carrier/CNAM lookups.
        /// </summary>
        /// <param name="day">Returns a list of usage for a given day within a month.</param>
        /// <param name="month">Returns a list of usage for a given month. For January: Month=1, for February: Month=2, etc.</param>
        /// <param name="year">Returns a list of usage for a given year.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <param name="product">Returns a list of all usage for a specific "product" or feature of TelAPI.</param>
        /// <returns></returns>
        public async Task<UsageResult> GetUsages(int? day, int? month, int? year, int? page, int? pageSize, Products? product)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetUsagesUri;

            if (day.HasValue) request.AddParameter("Day", day);
            if (month.HasValue) request.AddParameter("Month", month);
            if (year.HasValue) request.AddParameter("Year", year);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);
            if (product.HasValue) request.AddParameter("Product", (int)product.Value);

            return await Execute<UsageResult>(request);
        }

        /// <summary>
        /// Individual usage resources are assigned a Sid which can be used to access them. 
        /// In addition to the name and price of the feature used, usage resources also provide the date the usage occurred.
        /// </summary>
        /// <param name="sid">Usage sid</param>
        /// <returns></returns>
        public async Task<Usage> GetUsage(string sid)
        {
            Require.Argument(RequestUriParams.UsageSid, sid);

            var request = new RestRequest();
            request.Resource = RequestUri.GetUsageUri;
            request.AddUrlSegment(RequestUriParams.UsageSid, sid);

            return await Execute<Usage>(request);
        }
    }
}
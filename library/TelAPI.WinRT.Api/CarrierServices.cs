﻿using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// TelAPI provides a way to look up the carrier of a phone number via the REST API.
        /// </summary>
        /// <param name="phoneNumber">The number of the phone you are attempting to perform the carrier look up on.</param>
        /// <returns></returns>
        public async Task<CarrierLookupResult> CarrierLookup(string phoneNumber)
        {
            Require.Argument("PhoneNumber", phoneNumber);

            var request = new RestRequest();
            request.Resource = RequestUri.CarrierLookupUri;
            request.AddParameter(RequestUriParams.PhoneNumber, phoneNumber);

            return await Execute<CarrierLookupResult>(request);
        }

        /// <summary>
        /// TelAPI provides a way to look up the CNAM caller ID (name and address) information of a phone number via the REST API.
        /// </summary>
        /// <param name="phoneNumber">The number of the phone you are attempting to perform the CNAM look up on.</param>
        /// <returns></returns>
        public async Task<CNAMDipResult> CNAMLookup(string phoneNumber)
        {
            Require.Argument("PhoneNumber", phoneNumber);

            var request = new RestRequest();
            request.Resource = RequestUri.CNAMLookupUri;
            request.AddParameter(RequestUriParams.PhoneNumber, phoneNumber);

            return await Execute<CNAMDipResult>(request);
        }

        /// <summary>
        /// TelAPI provides an endpoint for performing BNA (Billing Name Address) lookups on numbers. 
        /// BNA lookups provide geolocation information for phone numbers. BNA lookups are currently only available for US numbers.
        /// </summary>
        /// <param name="phoneNumber">The number of the phone you are attempting to perform the BNA lookup on.</param>
        /// <returns></returns>
        public async Task<BNALookupResult> BnaLookup(string phoneNumber)
        {
            Require.Argument("PhoneNumber", phoneNumber);

            var request = new RestRequest();
            request.Resource = RequestUri.BnaLookup;
            request.AddParameter(RequestUriParams.PhoneNumber, phoneNumber);

            return await Execute<BNALookupResult>(request);
        }
    }
}

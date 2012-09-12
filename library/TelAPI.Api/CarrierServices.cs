using System;
using System.Collections.Generic;
using RestSharp.Validation;
using RestSharp;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// TelAPI provides a way to look up the carrier of a phone number via the REST API.
        /// </summary>
        /// <param name="phoneNumber">The number of the phone you are attempting to perform the carrier look up on.</param>
        /// <returns></returns>
        public CarrierLookupResult CarrierLookup(string phoneNumber)
        {
            Require.Argument("PhoneNumber", phoneNumber);

            var request = new RestRequest();
            request.Resource = RequestUri.CarrierLookupUri;
            request.AddParameter(RequestUriParams.PhoneNumber, phoneNumber);

            return Execute<CarrierLookupResult>(request);
        }

        /// <summary>
        /// TelAPI provides a way to look up the CNAM caller ID (name and address) information of a phone number via the REST API.
        /// </summary>
        /// <param name="phoneNumber">The number of the phone you are attempting to perform the CNAM look up on.</param>
        /// <returns></returns>
        public CNAMDipResult CNAMLookup(string phoneNumber)
        {
            Require.Argument("PhoneNumber", phoneNumber);

            var request = new RestRequest();
            request.Resource = RequestUri.CNAMLookupUri;
            request.AddParameter(RequestUriParams.PhoneNumber, phoneNumber);

            return Execute<CNAMDipResult>(request);
        }
    }
}

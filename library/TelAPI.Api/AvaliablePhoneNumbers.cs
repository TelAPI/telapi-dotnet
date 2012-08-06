using System;
using System.Collections.Generic;
using RestSharp.Validation;
using RestSharp.Extensions;
using RestSharp;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Request a list of available numbers 
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode)
        {
            return GetAvailablePhoneNumbers(isoCountryCode, null, null, null, null);
        }

        /// <summary>
        /// Request a list of available numbers 
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, string areaCode)
        {
            return GetAvailablePhoneNumbers(isoCountryCode, areaCode, null, null, null);
        }

        /// <summary>
        /// Request a list of available numbers
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <param name="contains">Specifies the desired characters contained within the available numbers to list.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, string contains)
        {
            return GetAvailablePhoneNumbers(isoCountryCode, areaCode, contains, null, null);
        }

        /// <summary>
        /// Request a list of available numbers
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <param name="contains">Specifies the desired characters contained within the available numbers to list.</param>
        /// <param name="inRegion">Specifies the desired region of the available numbers to be listed.</param>
        /// <param name="inPostalCode">Specifies the desired postal code of the available numbers to be listed.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, string contains, string inRegion, string inPostalCode)
        {
            Require.Argument("IsoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = RequestUri.AvailablePhoneNumbersUri;
            request.AddUrlSegment(RequestUriParams.IsoCountryCode, isoCountryCode);

            if (areaCode.HasValue()) request.AddParameter("AreaCode", areaCode);
            if (contains.HasValue()) request.AddParameter("Contains", contains);
            if (inRegion.HasValue()) request.AddParameter("InRegion", inRegion);
            if (inPostalCode.HasValue()) request.AddParameter("InPostalCode", inPostalCode);

            return Execute<AvailablePhoneNumberResult>(request);
        }
    }
}

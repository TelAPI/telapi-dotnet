using RestSharp;
using RestSharp.Validation;
using RestSharp.Extensions;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Request a list of available numbers 
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="type">Search for local (default) or toll free nubmers.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, AvaliablePhoneNumberType type)
        {
            return GetAvailablePhoneNumbers(isoCountryCode, null, null, null, null, type);
        }

        /// <summary>
        /// Request a list of available numbers 
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <param name="type">Search for local (default) or toll free nubmers.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, AvaliablePhoneNumberType type)
        {
            return GetAvailablePhoneNumbers(isoCountryCode, areaCode, null, null, null, type);
        }

        /// <summary>
        /// Request a list of available numbers
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <param name="contains">Specifies the desired characters contained within the available numbers to list.</param>
        /// <param name="type">Search for local (default) or toll free nubmers.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, string contains, AvaliablePhoneNumberType type)
        {
            return GetAvailablePhoneNumbers(isoCountryCode, areaCode, contains, null, null, type);
        }

        /// <summary>
        /// Request a list of available numbers
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <param name="contains">Specifies the desired characters contained within the available numbers to list.</param>
        /// <param name="inRegion">Specifies the desired region of the available numbers to be listed.</param>
        /// <param name="inPostalCode">Specifies the desired postal code of the available numbers to be listed.</param>
        /// <param name="type">Search for local (default) or toll free nubmers.</param>
        /// <returns></returns>
        public AvailablePhoneNumberResult GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, string contains, string inRegion, string inPostalCode, AvaliablePhoneNumberType type)
        {
            Require.Argument("IsoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = type == AvaliablePhoneNumberType.Local ? RequestUri.AvailablePhoneNumbersUri : RequestUri.AvailableTollFreePhoneNumbersUri;

            request.AddUrlSegment(RequestUriParams.IsoCountryCode, isoCountryCode);

            if (areaCode.HasValue()) request.AddParameter("AreaCode", areaCode);
            if (contains.HasValue()) request.AddParameter("Contains", contains);
            if (inRegion.HasValue()) request.AddParameter("InRegion", inRegion);
            if (inPostalCode.HasValue()) request.AddParameter("InPostalCode", inPostalCode);

            return Execute<AvailablePhoneNumberResult>(request);
        }
    }
}

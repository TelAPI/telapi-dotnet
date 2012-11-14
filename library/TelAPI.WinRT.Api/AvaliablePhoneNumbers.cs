using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Request a list of available numbers 
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <returns></returns>
        public async Task<AvailablePhoneNumberResult> GetAvailablePhoneNumbers(string isoCountryCode)
        {
            return await GetAvailablePhoneNumbers(isoCountryCode, null, null, null, null);
        }

        /// <summary>
        /// Request a list of available numbers 
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <returns></returns>
        public async Task<AvailablePhoneNumberResult> GetAvailablePhoneNumbers(string isoCountryCode, string areaCode)
        {
            return await GetAvailablePhoneNumbers(isoCountryCode, areaCode, null, null, null);
        }

        /// <summary>
        /// Request a list of available numbers
        /// </summary>
        /// <param name="isoCountryCode">Two letter country code of the available phone number.</param>
        /// <param name="areaCode">Code used to identify the phone numbers geographic origin. Found at the beginning of the number.</param>
        /// <param name="contains">Specifies the desired characters contained within the available numbers to list.</param>
        /// <returns></returns>
        public async Task<AvailablePhoneNumberResult> GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, string contains)
        {
            return await GetAvailablePhoneNumbers(isoCountryCode, areaCode, contains, null, null);
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
        public async Task<AvailablePhoneNumberResult> GetAvailablePhoneNumbers(string isoCountryCode, string areaCode, string contains, string inRegion, string inPostalCode)
        {
            Require.Argument("IsoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = RequestUri.AvailablePhoneNumbersUri;
            request.AddUrlSegment(RequestUriParams.IsoCountryCode, isoCountryCode);

            if (areaCode != null) request.AddParameter("AreaCode", areaCode);
            if (contains != null) request.AddParameter("Contains", contains);
            if (inRegion != null) request.AddParameter("InRegion", inRegion);
            if (inPostalCode != null) request.AddParameter("InPostalCode", inPostalCode);

            return await Execute<AvailablePhoneNumberResult>(request);
        }
    }
}
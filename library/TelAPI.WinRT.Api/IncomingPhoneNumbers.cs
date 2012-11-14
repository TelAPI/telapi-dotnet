using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Gets TelAPI phone number associated with an account
        /// </summary>
        /// <param name="phoneNumberSid">An alphanumeric string used for identification of incoming phone numbers.</param>
        /// <returns></returns>        
        public async Task<IncomingPhoneNumber> GetIncomingPhoneNumber(string phoneNumberSid)
        {
            Require.Argument("IncomingPhoneNumberSid", phoneNumberSid);

            var request = new RestRequest();
            request.Resource = RequestUri.IncomingPhoneNumberUri;
            request.AddUrlSegment(RequestUriParams.IncomingPhoneNumberSid, phoneNumberSid);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <returns></returns>
        public async Task<IncomingPhoneNumberResult>GetIncomingPhoneNumbers()
        {
            return await GetIncomingPhoneNumbers(null, null, null, null);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <param name="phoneNumber">Specifies what IncomingPhoneNumber resources should be returned in the list request.</param>
        /// <returns></returns>
        public async Task<IncomingPhoneNumberResult> GetInomingPhoneNumbers(string phoneNumber)
        {
            return await GetIncomingPhoneNumbers(phoneNumber, null, null, null);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <param name="phoneNumber">Specifies what IncomingPhoneNumber resources should be returned in the list request.</param>
        /// <param name="friendlyName">Specifies that only IncomingPhoneNumber resources matching the input FreindlyName should be returned in the list request.</param>
        /// <returns></returns>
        public async Task<IncomingPhoneNumberResult> GetIncomingPhoneNumbers(string phoneNumber, string friendlyName)
        {
            return await GetIncomingPhoneNumbers(phoneNumber, friendlyName, null, null);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <param name="phoneNumber">Specifies what IncomingPhoneNumber resources should be returned in the list request.</param>
        /// <param name="friendlyName">Specifies that only IncomingPhoneNumber resources matching the input FreindlyName should be returned in the list request.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public async Task<IncomingPhoneNumberResult> GetIncomingPhoneNumbers(string phoneNumber, string friendlyName, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.IncomingPhoneNumbersUri;

            if (phoneNumber != null) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName != null) request.AddParameter("FriendlyName", friendlyName);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return await Execute<IncomingPhoneNumberResult>(request);
        }

        /// <summary>
        /// Add new Incoming Phone Number to your TelAPI account
        /// </summary>
        /// <param name="phoneNumber">Desired phone number to add to the account (E.164 format).</param>
        /// <param name="areaCode">Desired area code of phone number to add to the account.</param>
        /// <returns></returns>
        public async Task<IncomingPhoneNumber> AddIncomingPhoneNumber(string phoneNumber, string areaCode)
        {
            Require.Argument("PhoneNumber", phoneNumber);
            Require.Argument("AreaCode", areaCode);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.CreateIncomingPhoneNumber;
            request.AddParameter("PhoneNumber", phoneNumber);
            request.AddParameter("AreaCode", areaCode);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Delete existing Incoming Phone number from account
        /// </summary>
        /// <param name="phoneNumber">Desired phone number to delete from account</param>
        /// <returns></returns>
        public async Task<IncomingPhoneNumber> DeleteIncomingPhoneNumber(string phoneNumberSid)
        {
            Require.Argument("IncomingPhoneNumberSid", phoneNumberSid);

            var request = new RestRequest(System.Net.Http.HttpMethod.Delete);
            request.Resource = RequestUri.DeleteIncomingPhoneNumberUri;
            request.AddUrlSegment(RequestUriParams.IncomingPhoneNumberSid, phoneNumberSid);

            return await Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Update existing Incoming Phone number
        /// </summary>
        /// <param name="phoneNumber">Desired Incoming phone number to update</param>
        /// <returns></returns>
        public async Task<IncomingPhoneNumber> UpdateIncomingPhoneNumber(IncomingPhoneNumber phoneNumber)
        {
            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.UpdateIncomingPhoneNumberUri;
            request.AddUrlSegment(RequestUriParams.IncomingPhoneNumberSid, phoneNumber.Sid);

            CreateIncomingPhoneNumberParams(phoneNumber, request);

            return await Execute<IncomingPhoneNumber>(request);
        }

        #region Helpers methods for populating request params

        private void CreateIncomingPhoneNumberParams(IncomingPhoneNumber phoneNumber, RestRequest request)
        {
            if (phoneNumber.FriendlyName != null) request.AddParameter("FriendlyName", phoneNumber.FriendlyName);
            if (phoneNumber.VoiceUrl != null) request.AddParameter("VoiceUrl", phoneNumber.VoiceUrl);
            if (phoneNumber.VoiceMethod != null) request.AddParameter("VoiceMethod", phoneNumber.VoiceMethod);
            if (phoneNumber.VoiceFallbackUrl != null) request.AddParameter("VoiceFallbackUrl", phoneNumber.VoiceFallbackUrl);
            if (phoneNumber.VoiceFallbackMethod != null) request.AddParameter("VoiceFallbackMethod", phoneNumber.VoiceFallbackMethod);
            if (phoneNumber.VoiceCallerIdLookup) request.AddParameter("VoiceCallerIdLookup", phoneNumber.VoiceCallerIdLookup);
            if (phoneNumber.SmsUrl != null) request.AddParameter("SmsUrl", phoneNumber.SmsUrl);
            if (phoneNumber.SmsMethod != null) request.AddParameter("SmsMethod", phoneNumber.SmsMethod);
            if (phoneNumber.SmsFallbackUrl != null) request.AddParameter("SmsFallbackUrl", phoneNumber.SmsFallbackUrl);
            if (phoneNumber.SmsFallbackMethod != null) request.AddParameter("SmsFallbackMethod", phoneNumber.SmsFallbackMethod);
            if (phoneNumber.HangupCallback != null) request.AddParameter("HangupCallback", phoneNumber.HangupCallback);
            if (phoneNumber.HangupCallbackMethod != null) request.AddParameter("HangupCallbackMethod", phoneNumber.HangupCallbackMethod);
            if (phoneNumber.HeartbeatUrl != null) request.AddParameter("HeartbeatUrl", phoneNumber.HeartbeatUrl);
            if (phoneNumber.HeartbeatMethod != null) request.AddParameter("HeartbeatMethod", phoneNumber.HeartbeatMethod);
        }

        #endregion
    }
}

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
        /// Gets TelAPI phone number associated with an account
        /// </summary>
        /// <param name="phoneNumberSid">An alphanumeric string used for identification of incoming phone numbers.</param>
        /// <returns></returns>        
        public IncomingPhoneNumber GetIncomingPhoneNumber(string phoneNumberSid)
        {
            Require.Argument("IncomingPhoneNumberSid", phoneNumberSid);

            var request = new RestRequest();
            request.Resource = RequestUri.IncomingPhoneNumberUri;
            request.AddUrlSegment(RequestUriParams.IncomingPhoneNumberSid, phoneNumberSid);

            return Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <returns></returns>
        public IncomingPhoneNumberResult GetIncomingPhoneNumbers()
        {
            return GetIncomingPhoneNumbers(null, null, null, null);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <param name="phoneNumber">Specifies what IncomingPhoneNumber resources should be returned in the list request.</param>
        /// <returns></returns>
        public IncomingPhoneNumberResult GetInomingPhoneNumbers(string phoneNumber)
        {
            return GetIncomingPhoneNumbers(phoneNumber, null, null, null);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <param name="phoneNumber">Specifies what IncomingPhoneNumber resources should be returned in the list request.</param>
        /// <param name="friendlyName">Specifies that only IncomingPhoneNumber resources matching the input FreindlyName should be returned in the list request.</param>
        /// <returns></returns>
        public IncomingPhoneNumberResult GetIncomingPhoneNumbers(string phoneNumber, string friendlyName)
        {
            return GetIncomingPhoneNumbers(phoneNumber, friendlyName, null, null);
        }

        /// <summary>
        /// Gets TelAPI phone numbers associated with an account
        /// </summary>
        /// <param name="phoneNumber">Specifies what IncomingPhoneNumber resources should be returned in the list request.</param>
        /// <param name="friendlyName">Specifies that only IncomingPhoneNumber resources matching the input FreindlyName should be returned in the list request.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public IncomingPhoneNumberResult GetIncomingPhoneNumbers(string phoneNumber, string friendlyName, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.IncomingPhoneNumbersUri;
            
            if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<IncomingPhoneNumberResult>(request);
        }

        /// <summary>
        /// Add new Incoming Phone Number to your TelAPI account
        /// </summary>
        /// <param name="phoneNumber">Desired phone number to add to the account (E.164 format).</param>
        /// <param name="areaCode">Desired area code of phone number to add to the account.</param>
        /// <returns></returns>
        public IncomingPhoneNumber AddIncomingPhoneNumber(string phoneNumber, string areaCode)
        {
            Require.Argument("PhoneNumber", phoneNumber);
            Require.Argument("AreaCode", areaCode);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.CreateIncomingPhoneNumber;
            request.AddParameter("PhoneNumber", phoneNumber);
            request.AddParameter("AreaCode", areaCode);

            return Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Delete existing Incoming Phone number from account
        /// </summary>
        /// <param name="phoneNumber">Desired phone number to delete from account</param>
        /// <returns></returns>
        public IncomingPhoneNumber DeleteIncomingPhoneNumber(string phoneNumberSid)
        {
            Require.Argument("IncomingPhoneNumberSid", phoneNumberSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = RequestUri.DeleteIncomingPhoneNumberUri;
            request.AddUrlSegment(RequestUriParams.IncomingPhoneNumberSid, phoneNumberSid);

            return Execute<IncomingPhoneNumber>(request);
        }

        /// <summary>
        /// Update existing Incoming Phone number
        /// </summary>
        /// <param name="phoneNumber">Desired Incoming phone number to update</param>
        /// <returns></returns>
        public IncomingPhoneNumber UpdateIncomingPhoneNumber(IncomingPhoneNumber phoneNumber)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.UpdateIncomingPhoneNumberUri;
            request.AddUrlSegment(RequestUriParams.IncomingPhoneNumberSid, phoneNumber.Sid);

            CreateIncomingPhoneNumberParams(phoneNumber, request);

            return Execute<IncomingPhoneNumber>(request);
        }

        #region Helpers methods for populating request params

        private void CreateIncomingPhoneNumberParams(IncomingPhoneNumber phoneNumber, RestRequest request)
        {
            if (phoneNumber.FriendlyName.HasValue()) request.AddParameter("FriendlyName", phoneNumber.FriendlyName);
            if (phoneNumber.VoiceUrl.HasValue()) request.AddParameter("VoiceUrl", phoneNumber.VoiceUrl);
            if (phoneNumber.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", phoneNumber.VoiceMethod);
            if (phoneNumber.VoiceFallbackUrl.HasValue()) request.AddParameter("VoiceFallbackUrl", phoneNumber.VoiceFallbackUrl);
            if (phoneNumber.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", phoneNumber.VoiceFallbackMethod);
            if (phoneNumber.VoiceCallerIdLookup.HasValue()) request.AddParameter("VoiceCallerIdLookup", phoneNumber.VoiceCallerIdLookup);
            if (phoneNumber.SmsUrl.HasValue()) request.AddParameter("SmsUrl", phoneNumber.SmsUrl);
            if (phoneNumber.SmsMethod.HasValue()) request.AddParameter("SmsMethod", phoneNumber.SmsMethod);
            if (phoneNumber.SmsFallbackUrl.HasValue()) request.AddParameter("SmsFallbackUrl", phoneNumber.SmsFallbackUrl);
            if (phoneNumber.SmsFallbackMethod.HasValue()) request.AddParameter("SmsFallbackMethod", phoneNumber.SmsFallbackMethod);
            if (phoneNumber.HangupCallback.HasValue()) request.AddParameter("HangupCallback", phoneNumber.HangupCallback);
            if (phoneNumber.HangupCallbackMethod.HasValue()) request.AddParameter("HangupCallbackMethod", phoneNumber.HangupCallbackMethod);
        } 

        #endregion
    }
}

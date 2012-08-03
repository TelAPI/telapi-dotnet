using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Receive SMS message. Make GET request
        /// </summary>
        /// <param name="smsMessageSid">An alphanumeric string used for identification of sms messages.</param>
        /// <returns></returns>
        public SmsMessage GetSmsMessage(string smsMessageSid)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetSmsMessageUri;
            request.AddUrlSegment(RequestUriParams.SmsMessageSid, smsMessageSid);

            return Execute<SmsMessage>(request);
        }

        /// <summary>
        /// Receive all SMS messages for current account. Make GET request
        /// </summary>
        /// <returns></returns>
        public SmsMessageResult GetSmsMessages()
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetSmsMessagesUri;            

            return Execute<SmsMessageResult>(request);
        }

        /// <summary>
        /// Receive SMS messages wich satisfiy criteria. Make GET request
        /// </summary>
        /// <param name="smsMessageOptions">Sms message options for narrowing search</param>
        /// <returns></returns>
        public SmsMessageResult GetSmsMessages(SmsMessageListOptions smsMessageOptions)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetSmsMessagesUri;

            CreateSmsMessageListOptions(smsMessageOptions, request);

            return Execute<SmsMessageResult>(request);
        }

        /// <summary>
        /// Send SMS message
        /// </summary>
        /// <param name="from">The number you want to display as sending the SMS. A surcharge will apply when sending via a custom From number.</param>
        /// <param name="to">The number you want to send the SMS to.</param>
        /// <param name="body">Text of the SMS message to be sent.</param>
        /// <returns></returns>
        public SmsMessage SendSmsMessage(string from, string to, string body)
        {
            return SendSmsMessage(from, to, body, string.Empty);
        }

        /// <summary>
        /// Send SMS message
        /// </summary>
        /// <param name="from">The number you want to display as sending the SMS. A surcharge will apply when sending via a custom From number.</param>
        /// <param name="to">The number you want to send the SMS to.</param>
        /// <param name="body">Text of the SMS message to be sent.</param>
        /// <param name="statusCallback">URL that a set of default parameters will be forwarded to once the SMS is complete.</param>
        /// <returns></returns>
        public SmsMessage SendSmsMessage(string from, string to, string body, string statusCallback)
        {
            Require.Argument("from", from);
            Require.Argument("to", to);
            Require.Argument("body", body);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.SendSmsMessageUri;
            request.AddParameter("From", from);
            request.AddParameter("To", to);
            request.AddParameter("Body", body);
            if (statusCallback.HasValue()) request.AddParameter("StatusCallback", statusCallback);

            return Execute<SmsMessage>(request);
        }

        /// <summary>
        /// Helper Method to populate RestRequest params
        /// </summary>
        /// <param name="smsMessageOptions">Sms message options</param>
        /// <param name="request">Rest request</param>
        private void CreateSmsMessageListOptions(SmsMessageListOptions smsMessageOptions, RestRequest request)
        {
            if (smsMessageOptions.To.HasValue()) request.AddParameter("To", smsMessageOptions.To);
            if (smsMessageOptions.From.HasValue()) request.AddParameter("From", smsMessageOptions.From);
            if (smsMessageOptions.DateSent.HasValue) request.AddParameter("DateSent", smsMessageOptions.DateSent.Value.ToString("yyyy-MM-dd"));
            if (smsMessageOptions.Page.HasValue) request.AddParameter("Page", smsMessageOptions.Page.Value);
            if (smsMessageOptions.PageSize.HasValue) request.AddParameter("PageSize", smsMessageOptions.PageSize.Value);
        }
    }
}

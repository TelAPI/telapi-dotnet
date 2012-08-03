using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Retrive Call details. Make GET request
        /// </summary>
        /// <param name="callSid"></param>
        /// <returns></returns>
        public Call GetCall(string callSid)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetCallUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);

            return Execute<Call>(request);
        }

        /// <summary>
        /// Retrive all calls. Make GET request
        /// </summary>
        /// <returns></returns>
        public CallResult GetCalls()
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetCallsUri;            

            return Execute<CallResult>(request);
        }

        /// <summary>
        /// Retrive all calls which satisfy CallOptions criteria. Make GET request
        /// </summary>
        /// <param name="callOptions">Call options to narrow search of calls</param>
        /// <returns></returns>
        public CallResult GetCalls(CallListOptions callOptions)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetCallsUri;

            CreateCallListOptions(callOptions, request);

            return Execute<CallResult>(request);
        }

        /// <summary>
        /// Initiate outbound call. Make POST request
        /// </summary>
        /// <param name="from">The number to call.</param>
        /// <param name="to">The number to display as calling.</param>
        /// <param name="url">The URL requested once the call connects.</param>
        /// <returns></returns>
        public Call MakeCall(string from, string to, string url)
        {
            return MakeCall(new CallOptions
            {
                From = from,
                To = to,
                Url = url
            });
        }

        /// <summary>
        /// Initiate outbound call with options. Make POST request
        /// </summary>
        /// <param name="callOptions">Call options</param>
        /// <returns></returns>
        public Call MakeCall(CallOptions callOptions)
        {
            Require.Argument("To", callOptions.To);
            Require.Argument("From", callOptions.From);
            Require.Argument("Url", callOptions.Url);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.MakeCallUri;

            CreateCallOptions(callOptions, request);

            return Execute<Call>(request);
        }

        /// <summary>
        /// Hangup up current active call. Make POST request
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls.</param>
        /// <returns></returns>
        public Call HangupCall(string callSid)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.HangupCallUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);            
            request.AddParameter("Status", HangupCallStatus.Completed.ToString().ToLower());

            return Execute<Call>(request);
        }

        /// <summary>
        /// Helper method to create populate Rest params
        /// </summary>
        /// <param name="callOptions">Call options</param>
        /// <param name="request">Rest Request</param>
        private void CreateCallOptions(CallOptions callOptions, RestRequest request)
        {
            request.AddParameter("To", callOptions.To);
            request.AddParameter("From", callOptions.From);
            request.AddParameter("Url", callOptions.Url);

            if (callOptions.ForwardedFrom.HasValue()) request.AddParameter("ForwardedFrom", callOptions.ForwardedFrom);
            if (callOptions.Method.HasValue()) request.AddParameter("Method", callOptions.Method);
            if (callOptions.FallbackUrl.HasValue()) request.AddParameter("FallbackUrl", callOptions.FallbackUrl);
            if (callOptions.FallbackMethod.HasValue()) request.AddParameter("FallbackMethod", callOptions.FallbackMethod);
            if (callOptions.StatusCallback.HasValue()) request.AddParameter("StatusCallback", callOptions.StatusCallback);
            if (callOptions.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", callOptions.StatusCallbackMethod);
            if (callOptions.SendDigits.HasValue()) request.AddParameter("SendDigits", callOptions.SendDigits);
            if (callOptions.Timeout.HasValue) request.AddParameter("Timeout", callOptions.Timeout);
            if (callOptions.HideCallerId.HasValue) request.AddParameter("HideCallerId", callOptions.HideCallerId);
        }

        /// <summary>
        /// Helper method to create populate Rest params
        /// </summary>
        /// <param name="callOptions">Call options</param>
        /// <param name="request">Rest Request</param>
        private void CreateCallListOptions(CallListOptions callListOptions, RestRequest request)
        {
            if (callListOptions.To.HasValue()) request.AddParameter("To", callListOptions.To);
            if (callListOptions.From.HasValue()) request.AddParameter("From", callListOptions.From);
            if (callListOptions.Status.HasValue()) request.AddParameter("Status", callListOptions.Status);
            if (callListOptions.StartTime.HasValue) request.AddParameter("StartTime", callListOptions.StartTime.Value.ToString("yyyy-MM-dd"));
            if (callListOptions.Page.HasValue) request.AddParameter("Page", callListOptions.Page);
            if (callListOptions.PageSize.HasValue) request.AddParameter("PageSize", callListOptions.PageSize);
        }
        
    }
}

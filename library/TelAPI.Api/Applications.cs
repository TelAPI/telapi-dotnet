using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Extensions;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Return application details
        /// </summary>
        /// <param name="applicationSid">An alphanumeric string used for identification of the application.</param>
        /// <returns></returns>
        public Application GetApplication(string applicationSid)
        {
            Require.Argument("ApplicationSid", applicationSid);

            var request = new RestRequest();
            request.Resource = RequestUri.ApplicationUri;
            request.AddUrlSegment(RequestUriParams.ApplicationSid, applicationSid);

            return Execute<Application>(request);
        }

        /// <summary>
        /// Return applications list
        /// </summary>
        /// <returns></returns>
        public ApplicationResult GetApplications()
        {
            return GetApplications(null, null, null);
        }

        /// <summary>
        /// Return applications list
        /// </summary>
        /// <param name="friendlyName">Specifies that only application resources matching the input FreindlyName should be returned in the list request.</param>
        /// <returns></returns>
        public ApplicationResult GetApplications(string friendlyName)
        {
            return GetApplications(friendlyName, null, null);
        }

        /// <summary>
        /// Return applications list
        /// </summary>
        /// <param name="friendlyName">Specifies that only application resources matching the input FreindlyName should be returned in the list request.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public ApplicationResult GetApplications(string friendlyName, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.ApplicationsUri;

            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<ApplicationResult>(request);
        }

        //TODO : Bug when returning App. Instead of single app info, service returns list of all apps

        /// <summary>
        /// Create a new application for managing TelAPI phone numbers
        /// </summary>
        /// <param name="application">Application object</param>
        /// <returns></returns>
        public Application CreateApplication(Application application)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.CreateApplicationUri;

            CreateApplicationParams(application, request);

            return Execute<Application>(request);
        }

        /// <summary>
        /// Update application data
        /// </summary>
        /// <param name="application">Application object</param>
        /// <returns></returns>
        public Application UpdateApplication(Application application)
        {
            Require.Argument("ApplicationSid", application.Sid);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.UpdateApplicationUri;
            request.AddUrlSegment(RequestUriParams.ApplicationSid, application.Sid);

            CreateApplicationParams(application, request);

            return Execute<Application>(request);
        }

        /// <summary>
        /// Delete application from TelApi account
        /// </summary>
        /// <param name="applicationSid">An alphanumeric string used for identification of the application.</param>
        /// <returns></returns>
        public Application DeleteApplication(string applicationSid)
        {
            Require.Argument("ApplicationSid", applicationSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = RequestUri.DeleteApplicationUri;
            request.AddUrlSegment("ApplicationSid", applicationSid);

            return Execute<Application>(request);
        }

        #region Helper methods
        
        /// <summary>
        /// Populate Rest request with application params
        /// </summary>
        /// <param name="application">Application object</param>
        /// <param name="request">Rest request</param>
        private void CreateApplicationParams(Application application, RestRequest request)
        {
            Require.Argument("FriendlyName", application.FriendlyName);
            request.AddParameter("FriendlyName", application.FriendlyName);

            if (application.VoiceUrl.HasValue()) request.AddParameter("VoiceUrl", application.VoiceUrl);
            if (application.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", application.VoiceMethod);
            if (application.VoiceFallbackUrl.HasValue()) request.AddParameter("VoiceFallbackUrl", application.VoiceFallbackUrl);
            if (application.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", application.VoiceFallbackMethod);
            if (application.VoiceCallerIdLookup.HasValue()) request.AddParameter("VoiceCallerIdLookup", application.VoiceCallerIdLookup);
            if (application.SmsUrl.HasValue()) request.AddParameter("SmsUrl", application.SmsUrl);
            if (application.SmsMethod.HasValue()) request.AddParameter("SmsMethod", application.SmsMethod);
            if (application.SmsFallbackUrl.HasValue()) request.AddParameter("SmsFallbackUrl", application.SmsFallbackUrl);
            if (application.SmsFallbackMethod.HasValue()) request.AddParameter("SmsFallbackMethod", application.SmsFallbackMethod);
            if (application.HeartbeatUrl.HasValue()) request.AddParameter("HeartbeatUrl", application.HeartbeatUrl);
            if (application.HeartbeatMethod.HasValue()) request.AddParameter("HeartbeatMethod", application.HeartbeatMethod);
            if (application.HangupCallback.HasValue()) request.AddParameter("HangupCallback", application.HangupCallback);
            if (application.HangupCallbackMethod.HasValue()) request.AddParameter("HangupCallbackMethod", application.HangupCallbackMethod);
        } 

        #endregion

    }
}

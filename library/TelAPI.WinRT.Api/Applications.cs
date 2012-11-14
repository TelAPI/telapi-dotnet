using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Return application details
        /// </summary>
        /// <param name="applicationSid">An alphanumeric string used for identification of the application.</param>
        /// <returns></returns>
        public async Task<Application> GetApplication(string applicationSid)
        {
            Require.Argument("ApplicationSid", applicationSid);

            var request = new RestRequest();
            request.Resource = RequestUri.ApplicationUri;
            request.AddUrlSegment(RequestUriParams.ApplicationSid, applicationSid);

            return await Execute<Application>(request);
        }

        /// <summary>
        /// Return applications list
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationResult> GetApplications()
        {
            return await GetApplications(null, null, null);
        }

        /// <summary>
        /// Return applications list
        /// </summary>
        /// <param name="friendlyName">Specifies that only application resources matching the input FreindlyName should be returned in the list request.</param>
        /// <returns></returns>
        public async Task<ApplicationResult> GetApplications(string friendlyName)
        {
            return await GetApplications(friendlyName, null, null);
        }

        /// <summary>
        /// Return applications list
        /// </summary>
        /// <param name="friendlyName">Specifies that only application resources matching the input FreindlyName should be returned in the list request.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public async Task<ApplicationResult> GetApplications(string friendlyName, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.ApplicationsUri;

            if (friendlyName != null) request.AddParameter("FriendlyName", friendlyName);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return await Execute<ApplicationResult>(request);
        }

        /// <summary>
        /// Create a new application for managing TelAPI phone numbers
        /// </summary>
        /// <param name="application">Application object</param>
        /// <returns></returns>
        public async Task<Application> CreateApplication(Application application)
        {
            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.CreateApplicationUri;

            CreateApplicationParams(application, request);

            return await Execute<Application>(request);
        }

        /// <summary>
        /// Update application data
        /// </summary>
        /// <param name="application">Application object</param>
        /// <returns></returns>
        public async Task<Application> UpdateApplication(Application application)
        {
            Require.Argument("ApplicationSid", application.Sid);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.UpdateApplicationUri;
            request.AddUrlSegment(RequestUriParams.ApplicationSid, application.Sid);

            CreateApplicationParams(application, request);

            return await Execute<Application>(request);
        }

        /// <summary>
        /// Delete application from TelApi account
        /// </summary>
        /// <param name="applicationSid">An alphanumeric string used for identification of the application.</param>
        /// <returns></returns>
        public async Task<Application> DeleteApplication(string applicationSid)
        {
            Require.Argument("ApplicationSid", applicationSid);

            var request = new RestRequest(System.Net.Http.HttpMethod.Delete);
            request.Resource = RequestUri.DeleteApplicationUri;
            request.AddUrlSegment(RequestUriParams.ApplicationSid, applicationSid);

            return await Execute<Application>(request);
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

            if (application.VoiceUrl != null) request.AddParameter("VoiceUrl", application.VoiceUrl);
            if (application.VoiceMethod != null) request.AddParameter("VoiceMethod", application.VoiceMethod);
            if (application.VoiceFallbackUrl != null) request.AddParameter("VoiceFallbackUrl", application.VoiceFallbackUrl);
            if (application.VoiceFallbackMethod != null) request.AddParameter("VoiceFallbackMethod", application.VoiceFallbackMethod);
            if (application.VoiceCallerIdLookup != null) request.AddParameter("VoiceCallerIdLookup", application.VoiceCallerIdLookup);
            if (application.SmsUrl != null) request.AddParameter("SmsUrl", application.SmsUrl);
            if (application.SmsMethod != null) request.AddParameter("SmsMethod", application.SmsMethod);
            if (application.SmsFallbackUrl != null) request.AddParameter("SmsFallbackUrl", application.SmsFallbackUrl);
            if (application.SmsFallbackMethod != null) request.AddParameter("SmsFallbackMethod", application.SmsFallbackMethod);
            if (application.HeartbeatUrl != null) request.AddParameter("HeartbeatUrl", application.HeartbeatUrl);
            if (application.HeartbeatMethod != null) request.AddParameter("HeartbeatMethod", application.HeartbeatMethod);
            if (application.HangupCallback != null) request.AddParameter("HangupCallback", application.HangupCallback);
            if (application.HangupCallbackMethod != null) request.AddParameter("HangupCallbackMethod", application.HangupCallbackMethod);
        }

        #endregion
    }
}

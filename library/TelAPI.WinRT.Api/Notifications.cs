using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationSid"></param>
        /// <returns></returns>
        public async Task<Notification> GetNotification(string notificationSid)
        {
            Require.Argument("NotificationsSid", notificationSid);

            var request = new RestRequest();
            request.Resource = RequestUri.NotificationUri;
            request.AddUrlSegment(RequestUriParams.NotificationSid, notificationSid);

            return await Execute<Notification>(request);
        }

        /// <summary>
        /// A lists of every notification associated with an account
        /// </summary>
        /// <returns></returns>
        public async Task<NotificationResult> GetAccountNotifications()
        {
            return await GetAccountNotifications(null, null, null);
        }

        /// <summary>
        /// A lists of every notification associated with an account
        /// </summary>
        /// <param name="log">Specifies that only notifications with the given log level value should be listed.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public async Task<NotificationResult> GetAccountNotifications(NotificationLog? log, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.NotificationsUri;

            if (log.HasValue) request.AddParameter("Log", (int)log);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return await Execute<NotificationResult>(request);
        }

        /// <summary>
        /// A list of only notifications associated with a given CallSid
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls.</param>
        /// <returns></returns>

        public async Task<NotificationResult> GetCallNotifications(string callSid)
        {
            return await GetCallNotifications(callSid, null, null, null);
        }

        /// <summary>
        /// A list of only notifications associated with a given CallSid
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls.</param>
        /// <param name="log">Specifies that only notifications with the given log level value should be listed.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public async Task<NotificationResult> GetCallNotifications(string callSid, NotificationLog? log, int? page, int? pageSize)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = RequestUri.CallNotificationUri;
            request.AddUrlSegment("CallSid", callSid);

            if (log.HasValue) request.AddParameter("Log", (int)log);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return await Execute<NotificationResult>(request);
        }
    }
}

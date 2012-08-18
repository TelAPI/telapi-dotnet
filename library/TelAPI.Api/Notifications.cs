using System;
using RestSharp.Validation;
using RestSharp;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationSid"></param>
        /// <returns></returns>
        public Notification GetNotification(string notificationSid)
        {
            Require.Argument("NotificationsSid", notificationSid);

            var request = new RestRequest();
            request.Resource = RequestUri.NotificationUri;
            request.AddUrlSegment(RequestUriParams.NotificationSid, notificationSid);

            return Execute<Notification>(request);
        }

        /// <summary>
        /// A lists of every notification associated with an account
        /// </summary>
        /// <returns></returns>
        public NotificationResult GetAccountNotifications()
        {
            return GetAccountNotifications(null, null, null);
        }
        
        /// <summary>
        /// A lists of every notification associated with an account
        /// </summary>
        /// <param name="log">Specifies that only notifications with the given log level value should be listed.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public NotificationResult GetAccountNotifications(NotificationLog? log, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.NotificationsUri;

            if (log.HasValue) request.AddParameter("Log", (int)log);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<NotificationResult>(request);
        }

        /// <summary>
        /// A list of only notifications associated with a given CallSid
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls.</param>
        /// <returns></returns>
        
        public NotificationResult GetCallNotifications(string callSid)
        {
            return GetCallNotifications(callSid, null, null, null);
        }

        /// <summary>
        /// A list of only notifications associated with a given CallSid
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls.</param>
        /// <param name="log">Specifies that only notifications with the given log level value should be listed.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public NotificationResult GetCallNotifications(string callSid, NotificationLog? log, int? page, int? pageSize)
        {
            Require.Argument("callSid", callSid);

            var request = new RestRequest();
            request.Resource = RequestUri.CallNotificationUri;
            request.AddUrlSegment("CallSid", callSid);

            if (log.HasValue) request.AddParameter("Log", (int)log);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<NotificationResult>(request);
        }
    }
}

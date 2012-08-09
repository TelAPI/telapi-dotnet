using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class NotificationTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Account_Notifications()
        {
            var notifications = _client.GetAccountNotifications();

            Assert.NotNull(notifications);
        }

        [Fact]
        public void Can_I_Get_Call_Notifications()
        {
            var list = _client.GetCalls();
            var call = list.Calls[0];

            var notifications = _client.GetCallNotifications(call.Sid);

            Assert.NotNull(notifications);
        }

        [Fact]
        public void Can_I_Get_Notification()
        {
            var list = _client.GetAccountNotifications();
            var notification = list.Notifications[0];

            var notificationToCheck = _client.GetNotification(notification.Sid);

            Assert.Equal(notification.Sid, notificationToCheck.Sid);
        }
    }
}

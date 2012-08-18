using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class NotificationTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Account_Notifications()
        {
            var notifications = Client.GetAccountNotifications();

            Assert.NotNull(notifications);
        }

        [Fact]
        public void Can_I_Get_Account_Notification()
        {
            var list = Client.GetAccountNotifications();
            var notification = list.Notifications[0];

            var notificationToCheck = Client.GetNotification(notification.Sid);

            Assert.NotNull(list);
            Assert.NotNull(notification);
            Assert.NotNull(notificationToCheck);
            Assert.Equal(notification.Sid, notificationToCheck.Sid);
        }
    }
}

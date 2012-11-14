using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class NotificationTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Account_Notifications()
        {
            var notifications = await Client.GetAccountNotifications();

            Assert.NotNull(notifications);
        }

        [Fact]
        public async Task Can_I_Get_Account_Notification()
        {
            var list = await Client.GetAccountNotifications();
            var notification = list.Notifications[0];

            var notificationToCheck = await Client.GetNotification(notification.Sid);

            Assert.NotNull(list);
            Assert.NotNull(notification);
            Assert.NotNull(notificationToCheck);
            Assert.Equal(notification.Sid, notificationToCheck.Sid);
        }
    }
}

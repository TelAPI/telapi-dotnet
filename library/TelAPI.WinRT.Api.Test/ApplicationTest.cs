using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class ApplicationTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Create_And_Get__And_Delete_Application()
        {
            var newApp = new Application();
            newApp.FriendlyName = "Application By xUnit";
            newApp.HeartbeatMethod = HttpMethod.Get.ToString();

            var application = await Client.CreateApplication(newApp);
            var receivedApplication = await Client.GetApplication(application.Sid);
            var deleteApplication = await Client.DeleteApplication(application.Sid);

            Assert.NotNull(application);
            Assert.NotNull(receivedApplication);
            Assert.NotNull(deleteApplication);
            Assert.Equal(application.Sid, receivedApplication.Sid);
            Assert.Equal(application.Sid, deleteApplication.Sid);
        }

        [Fact]
        public async Task Can_I_Get_Application_List()
        {
            var newApp = new Application();
            newApp.FriendlyName = "Application By xUnit";

            var application = await Client.CreateApplication(newApp);
            var apps = await Client.GetApplications();
            Client.DeleteApplication(application.Sid);

            Assert.NotNull(apps);
            Assert.NotEmpty(apps.Applications);
        }

        [Fact]
        public async Task Can_I_Get_Application_List_With_Conditions()
        {
            var newApp = new Application();
            newApp.FriendlyName = "Application By xUnit";

            var application = await Client.CreateApplication(newApp);
            var apps = await Client.GetApplications(newApp.FriendlyName);
            Client.DeleteApplication(application.Sid);

            Assert.NotNull(apps);
            Assert.NotEmpty(apps.Applications);
        }

        [Fact]
        public async Task Can_I_Update_Application()
        {
            var newApp = new Application();
            newApp.FriendlyName = "Application By xUnit";

            var application = await Client.CreateApplication(newApp);

            string newFriendlyName = "Applicaton By xUnit #update";
            application.FriendlyName = newFriendlyName;

            var receivedApp = await Client.UpdateApplication(application);
            Client.DeleteApplication(application.Sid);

            Assert.NotNull(application);
            Assert.NotNull(receivedApp);
            Assert.Equal(newFriendlyName, receivedApp.FriendlyName);
        }

        [Fact]
        public async Task Can_I_Delete_Application()
        {
            var newApp = new Application();
            newApp.FriendlyName = "Application By xUnit";

            var application = await Client.CreateApplication(newApp);
            var receivedApp = await Client.DeleteApplication(application.Sid);

            Assert.NotNull(application);
            Assert.NotNull(receivedApp);
            Assert.Equal(application.Sid, receivedApp.Sid);
        }           

    }
}

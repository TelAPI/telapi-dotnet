using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class ApplicationTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Create_And_Get_Application()
        {
            var newApp = new Application();
            newApp.FriendlyName = "Test app";

            var application = _client.CreateApplication(newApp);
            var receivedApplication = _client.GetApplication(application.Sid);

            Assert.NotNull(application);
            Assert.NotNull(receivedApplication);
            Assert.Equal(application.Sid, receivedApplication.Sid);
        }

        [Fact]
        public void Can_I_Get_Application_List()
        {
            var apps = _client.GetApplications();

            Assert.NotNull(apps);
        }

        [Fact]
        public void Can_I_Get_Application_List_With_Conditions()
        {
            var pageSize = 1;
            var appsWithCondition = _client.GetApplications("Test app", null, pageSize);

            Assert.NotNull(appsWithCondition);
            Assert.Equal(pageSize, appsWithCondition.PageSize);
        }

        [Fact]
        public void Can_I_Update_Application()
        {
            var newAppName = "Test app updated";

            var app = _client.GetApplications("Test app").Applications[0];
            app.FriendlyName = newAppName;

            var receivedApp = _client.UpdateApplication(app);

            Assert.NotNull(receivedApp);
            Assert.Equal(newAppName, receivedApp.FriendlyName);
        }

        [Fact]
        public void Can_I_Delete_Application()
        {
            var app = _client.GetApplications("Test app").Applications[0];
            var receivedApp = _client.DeleteApplication(app.Sid);

            Assert.NotNull(receivedApp);
            Assert.Equal(app.Sid, receivedApp.Sid);
        }           

    }
}

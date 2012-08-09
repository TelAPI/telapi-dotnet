using System;
using Xunit;
using TelAPI;

namespace TelAPI.Api.Test
{
    public class AccountTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Account()
        {
            var expectedFriendlyName = "igor.belsa@calyx.hr";
            var account = _client.GetAccount();

            Assert.NotNull(account);
            Assert.Equal(expectedFriendlyName, account.FriendlyName);
        }
    }
}

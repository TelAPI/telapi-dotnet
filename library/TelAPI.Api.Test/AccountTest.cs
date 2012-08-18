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
            var account = Client.GetAccount();

            Assert.NotNull(account);
        }
    }
}

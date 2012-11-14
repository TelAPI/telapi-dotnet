using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;
using TelAPI;

namespace TelAPI.Api.Test
{
    public class AccountTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Account()
        {
            var account = await Client.GetAccount();

            Debug.WriteLine(account.AccountBalance);

            Assert.NotNull(account);
        }
    }
}

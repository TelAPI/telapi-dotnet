using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class FraudTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Fraud_Resources()
        {
            var resources = await Client.GetFraudControlResources();
            Assert.NotNull(resources);
        }

        [Fact]
        public async Task Can_I_Authorize_Destination()
        {
            var destination = await Client.AuthorizeDestination(TestCountryCode);
            Assert.NotNull(destination);
        }

        [Fact]
        public async Task Can_I_Block_Destination()
        {
            var destination = await Client.BlockDestination(TestCountryCode);
            Assert.NotNull(destination);
        }

        [Fact]
        public async Task Can_I_Extend_Destination()
        {
            var destination = await Client.ExtendDestinationAuth(TestCountryCode);

            Assert.NotNull(destination);
        }

        [Fact]
        public async Task Can_I_Whitelist_Destination()
        {
            var destination = await Client.WhitelistDestination(TestCountryCode);

            Assert.NotNull(destination);
        }
    }
}

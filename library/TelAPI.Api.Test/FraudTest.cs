using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class FraudTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Fraud_Resources()
        {
            var resources = _client.GetFraudControlResources();

            Assert.NotNull(resources);
        }

        [Fact]
        public void Can_I_Authorize_Destination()
        {
            var destination = _client.AuthorizeDestination("HR");

            Assert.NotNull(destination);
        }

        [Fact]
        public void Can_I_Block_Destination()
        {
            var destination = _client.BlockDestination("HR");

            Assert.NotNull(destination);
        }

        [Fact]
        public void Can_I_Extend_Destination()
        {
            var destination = _client.ExtendDestinationAuth("HR");

            Assert.NotNull(destination);
        }

        [Fact]
        public void Can_I_Whitelist_Destination()
        {
            var destination = _client.WhitelistDestination("HR");

            Assert.NotNull(destination);
        }
    }
}

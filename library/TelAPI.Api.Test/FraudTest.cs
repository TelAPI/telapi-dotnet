﻿using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class FraudTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Fraud_Resources()
        {
            var resources = Client.GetFraudControlResources();
            Assert.NotNull(resources);
        }

        [Fact]
        public void Can_I_Authorize_Destination()
        {
            var destination = Client.AuthorizeDestination(TestCountryCode);
            Assert.NotNull(destination);
        }

        [Fact]
        public void Can_I_Block_Destination()
        {
            var destination = Client.BlockDestination(TestCountryCode);
            Assert.NotNull(destination);
        }

        [Fact]
        public void Can_I_Extend_Destination()
        {
            var destination = Client.ExtendDestinationAuth(TestCountryCode);

            Assert.NotNull(destination);
        }

        [Fact]
        public void Can_I_Whitelist_Destination()
        {
            var destination = Client.WhitelistDestination(TestCountryCode);

            Assert.NotNull(destination);
        }
    }
}

using System;
using Xunit;
using System.Threading;

namespace TelAPI.Api.Test
{
    public class FraudTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Fraud_Resources()
        {
            var resources = Client.GetFraudControlResources();
            Assert.NotNull(resources);

            foreach (var resource in resources.Frauds)
            {
                foreach (var country in resource.Destinations.Authorized)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }

                foreach (var country in resource.Destinations.Blocked)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }

                foreach (var country in resource.Destinations.Whitelisted)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }
            }
        }

        [Fact]
        public void Can_I_Authorize_Destination()
        {
            var resources = Client.AuthorizeDestination(TestCountryCode);
            Assert.NotNull(resources);

            foreach (var resource in resources.Frauds)
            {
                foreach (var country in resource.Destinations.Authorized)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }
            }
        }

        [Fact]
        public void Can_I_Block_Destination()
        {
            var resources = Client.BlockDestination(TestCountryCode);
            Assert.NotNull(resources);

            foreach (var resource in resources.Frauds)
            {
                foreach (var country in resource.Destinations.Blocked)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }
            }
        }

        [Fact]
        public void Can_I_Extend_Destination()
        {
            var resources = Client.ExtendDestinationAuth(TestCountryCode);
            Assert.NotNull(resources);

            foreach (var resource in resources.Frauds)
            {
                foreach (var country in resource.Destinations.Authorized)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }
            }
        }

        [Fact]
        public void Can_I_Whitelist_Destination()
        {
            var resources = Client.WhitelistDestination(TestCountryCode);
            Assert.NotNull(resources);

            foreach (var resource in resources.Frauds)
            {
                foreach (var country in resource.Destinations.Whitelisted)
                {
                    Console.WriteLine("{0}", country.CountryName);
                }
            }
        }
    }
}

using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class CarrierServiceTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Carrier_Lookup()
        {
            var carriers = Client.CarrierLookup(PhoneNumberFrom);
            foreach (var carrier in carriers.CarrierLookups)
            {
                Console.WriteLine("{0}", carrier.Carrier);
            }

            Assert.NotNull(carriers);
        }

        [Fact]
        public void Can_I_Get_CNAM_Lookup()
        {
            var cnams = Client.CNAMLookup(PhoneNumberFrom);
            foreach (var cnam in cnams.CNAMDips)
            {
                Console.WriteLine("{0}", cnam.Body);
            }

            Assert.NotNull(cnams);
        }

        [Fact]
        public void Can_I_Get_Bna_Lookup()
        {
            var result = Client.BnaLookup(PhoneNumberFrom);
            foreach (var r in result.BNALookups)
            {
                Console.WriteLine("{0} {1} {2}", r.City, r.FirstName, r.LastName);
            }

            Assert.NotNull(result);
        }
    }
}

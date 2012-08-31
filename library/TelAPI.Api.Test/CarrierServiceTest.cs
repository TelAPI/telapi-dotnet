using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class CarrierServiceTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Carrier_Lookup()
        {
            var carrier = Client.CarrierLookup(PhoneNumberFrom);
            Assert.NotNull(carrier);

            Console.WriteLine("{0}", carrier.Carrier);
        }

        [Fact]
        public void Can_I_Get_CNAM_Lookup()
        {
            var cnamDips = Client.CNAMLookup(PhoneNumberFrom);
            Assert.NotNull(cnamDips);

            foreach (var cnamDip in cnamDips.CNAMDips)
            {
                Console.WriteLine("{0}", cnamDip.Body);
            }
        }
    }
}

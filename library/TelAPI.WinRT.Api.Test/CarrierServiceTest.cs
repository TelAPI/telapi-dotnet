using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class CarrierServiceTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Carrier_Lookup()
        {
            var carriers = await Client.CarrierLookup(PhoneNumberFrom);
            foreach (var carrier in carriers.CarrierLookups)
            {
                Debug.WriteLine("{0}", carrier.Carrier);
            }

            Assert.NotNull(carriers);
        }

        [Fact]
        public async Task Can_I_Get_CNAM_Lookup()
        {
            var cnams = await Client.CNAMLookup(PhoneNumberFrom);
            foreach (var cnam in cnams.CNAMDips)
            {
                Debug.WriteLine("{0}", cnam.Body);
            }

            Assert.NotNull(cnams);
        }
    }
}

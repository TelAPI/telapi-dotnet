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
        }

        [Fact]
        public void Can_I_Get_CNAM_Lookup()
        {
            var cnam = Client.CNAMLookup(PhoneNumberFrom);
            Assert.NotNull(cnam);
        }
    }
}

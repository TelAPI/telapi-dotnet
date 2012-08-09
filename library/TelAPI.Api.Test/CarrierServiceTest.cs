using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class CarrierServiceTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Carrier_Lookup()
        {
            var carrier = _client.CarrierLookup("+123456789");
            Assert.NotNull(carrier);
        }

        [Fact]
        public void Can_I_Get_CNAM_Lookup()
        {
            var cnam = _client.CNAMLookup("+12345678");
            Assert.NotNull(cnam);
        }
    }
}

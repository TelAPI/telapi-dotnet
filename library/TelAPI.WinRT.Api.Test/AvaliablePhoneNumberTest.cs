using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class AvaliablePhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Avaliable_Phone_Numbers_Local()
        {
            var numbers = await Client.GetAvailablePhoneNumbers(IsoCountryCode, AvaliablePhoneNumberType.Local);
            Assert.NotNull(numbers);
        }

        [Fact]
        public async Task Can_I_Get_Avaliable_Phone_Numbers_TollFree()
        {
            var numbers = await Client.GetAvailablePhoneNumbers(IsoCountryCode, AvaliablePhoneNumberType.TollFree);
            Assert.NotNull(numbers);
        }         
    }
}

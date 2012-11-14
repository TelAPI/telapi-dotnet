using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class AvaliablePhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Avaliable_Phone_Numbers()
        {
            var numbers = await Client.GetAvailablePhoneNumbers(IsoCountryCode);
            Assert.NotNull(numbers);
        }       
    }
}

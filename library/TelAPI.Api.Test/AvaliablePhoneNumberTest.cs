using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class AvaliablePhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Avaliable_Phone_Numbers_Local()
        {
            var numbers = Client.GetAvailablePhoneNumbers(IsoCountryCode, AvaliablePhoneNumberType.Local);
            Assert.NotNull(numbers);
        }

        [Fact]
        public void Can_I_Get_Avaliable_Phone_Numbers_TollFree()
        {
            var numbers = Client.GetAvailablePhoneNumbers(IsoCountryCode, AvaliablePhoneNumberType.TollFree);
            Assert.NotNull(numbers);
        }  
    }
}

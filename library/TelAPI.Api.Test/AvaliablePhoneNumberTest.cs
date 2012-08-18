using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class AvaliablePhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Avaliable_Phone_Numbers()
        {
            var numbers = Client.GetAvailablePhoneNumbers(IsoCountryCode);
            Assert.NotNull(numbers);
        }       
    }
}

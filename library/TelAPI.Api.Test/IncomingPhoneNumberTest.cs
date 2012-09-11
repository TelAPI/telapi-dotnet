using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class IncomingPhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Add_And_Get_And_Delete_Phone_Number()
        {
            var numbers = Client.GetAvailablePhoneNumbers(IsoCountryCode);
            var possibleNumber = numbers.AvailablePhoneNumbers[0];
            var newNumber = Client.AddIncomingPhoneNumber(possibleNumber.PhoneNumber, possibleNumber.NPA);
            var getNumber = Client.GetIncomingPhoneNumber(newNumber.Sid);
            var deleteNumber = Client.DeleteIncomingPhoneNumber(newNumber.Sid);

            Assert.NotNull(numbers);
            Assert.NotNull(possibleNumber);
            Assert.NotNull(newNumber);
            Assert.NotNull(getNumber);
            Assert.NotNull(deleteNumber);
            Assert.Equal(possibleNumber.PhoneNumber, newNumber.PhoneNumber);
            Assert.Equal(newNumber.Sid, deleteNumber.Sid);
        }

        [Fact]
        public void Can_I_Get_Phone_Number_List()
        {
            var list = Client.GetIncomingPhoneNumbers();
            Assert.NotNull(list);
        }

        [Fact]
        public void Can_I_Get_Phone_Number_List_With_Attributes()
        {
            var list = Client.GetIncomingPhoneNumbers(null, null, null, 1);
            Assert.NotNull(list);
        }
    }
}

using System;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class IncomingPhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Add_And_Get_And_Delete_Phone_Number()
        {
            var numbers = await Client.GetAvailablePhoneNumbers(IsoCountryCode, AvaliablePhoneNumberType.Local);
            var possibleNumber = numbers.AvailablePhoneNumbers[0];
            var newNumber = await Client.AddIncomingPhoneNumber(possibleNumber.PhoneNumber, possibleNumber.NPA);
            var getNumber = await Client.GetIncomingPhoneNumber(newNumber.Sid);
            var deleteNumber = await Client.DeleteIncomingPhoneNumber(newNumber.Sid);

            Assert.NotNull(numbers);
            Assert.NotNull(possibleNumber);
            Assert.NotNull(newNumber);
            Assert.NotNull(getNumber);
            Assert.NotNull(deleteNumber);
            Assert.Equal(possibleNumber.PhoneNumber, newNumber.PhoneNumber);
            Assert.Equal(newNumber.Sid, deleteNumber.Sid);
        }

        [Fact]
        public async Task Can_I_Get_Phone_Number_List()
        {
            var list = await Client.GetIncomingPhoneNumbers();
            Assert.NotNull(list);
        }

        [Fact]
        public async Task Can_I_Get_Phone_Number_List_With_Attributes()
        {
            var list = await Client.GetIncomingPhoneNumbers(null, null, null, 1);
            Assert.NotNull(list);
        }

        [Fact]
        public async Task Can_I_Update_Number()
        {
            var n = await Client.GetIncomingPhoneNumbers();
            var number = n.IncomingPhoneNumbers[0]; 
            number.HeartbeatUrl = "http://www.my-heartbeat-will-go-on.com";
            number.HeartbeatMethod = "GET";

            var update = await Client.UpdateIncomingPhoneNumber(number);

            Assert.NotNull(number);
            Assert.NotNull(update);
            Assert.Equal(number.Sid, update.Sid);
        }
    }
}

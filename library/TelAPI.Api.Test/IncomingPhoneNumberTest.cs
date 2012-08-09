using System;
using Xunit;

namespace TelAPI.Api.Test
{
    public class IncomingPhoneNumberTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_Phone_Number()
        {
            var list = _client.GetIncomingPhoneNumbers();
            var numberToCheck = list.IncomingPhoneNumbers[0];

            var numberToGet = _client.GetIncomingPhoneNumber(numberToCheck.Sid);

            Assert.Equal(numberToCheck.Sid, numberToGet.Sid);
        }

        [Fact]
        public void Can_I_Get_Phone_Number_List()
        {
            var list = _client.GetIncomingPhoneNumbers();

            Assert.NotNull(list);
        }

        [Fact]
        public void Can_I_Add_And_Delete_Phone_Number()
        {
            var possibleNumber = _client.GetAvailablePhoneNumbers("US");
            var newNumber = _client.AddIncomingPhoneNumber(possibleNumber.AvailablePhoneNumbers[0].PhoneNumber, "480");

            var deleteNumber = _client.DeleteIncomingPhoneNumber(newNumber.PhoneNumber);

            Assert.Equal(newNumber.Sid, deleteNumber.Sid);
        }

        [Fact]
        public void Can_I_Update_Phone_Number()
        {
            var list = _client.GetIncomingPhoneNumbers();
            var numberToUpdate = list.IncomingPhoneNumbers[0];

            numberToUpdate.VoiceUrl = "http://www.fake.com";

            var numberToCheck = _client.UpdateIncomingPhoneNumber(numberToUpdate);

            Assert.Equal(numberToUpdate.Sid, numberToCheck.Sid);
        }
    }
}

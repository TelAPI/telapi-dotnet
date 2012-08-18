using System;
using System.Collections.Generic;
using Xunit;

namespace TelAPI.Api.Test
{
    public class SmsTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Get_And_Send_Sms()
        {
            var newSms = Client.SendSmsMessage(PhoneNumberFrom, PhoneNumberTo, "Hello world");
            var receivedSms = Client.GetSmsMessage(newSms.Sid);

            Assert.Equal(newSms.Sid, receivedSms.Sid);
        }

        [Fact]
        public void Can_I_Get_Sms_List()
        {
            var smsList = Client.GetSmsMessages();

            Assert.NotNull(smsList);            
        }

        [Fact]
        public void Can_I_Get_Sms_List_With_Condition()
        {
            var conditions = new SmsMessageListOptions();
            conditions.PageSize = 5;

            var smsListWithCondition = Client.GetSmsMessages(conditions);

            Assert.NotNull(smsListWithCondition);
            Assert.Equal(conditions.PageSize, smsListWithCondition.PageSize);
        }
    }
}

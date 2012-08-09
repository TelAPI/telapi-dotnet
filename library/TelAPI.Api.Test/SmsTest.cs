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
            //var newSms = _client.SendSmsMessage("+12408446005 ", "+12246321739", "Hello world");
            //var receivedSms = _client.GetSmsMessage(newSms.Sid);

            //Assert.Equal(newSms.Sid, receivedSms.Sid);
        }

        [Fact]
        public void Can_I_Get_Sms_List()
        {
            var smsList = _client.GetSmsMessages();

            Assert.NotNull(smsList);            
        }

        [Fact]
        public void Can_I_Get_Sms_List_With_Condition()
        {
            var conditions = new SmsMessageListOptions();
            conditions.PageSize = 5;

            var smsListWithCondition = _client.GetSmsMessages(conditions);

            Assert.NotNull(smsListWithCondition);
            Assert.Equal(conditions.PageSize, smsListWithCondition.PageSize);
        }
    }
}

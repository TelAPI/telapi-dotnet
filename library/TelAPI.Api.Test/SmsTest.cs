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
            var random = new Random();
            var newSms = Client.SendSmsMessage(PhoneNumberFrom, PhoneNumberTo, "Hello world" + random.Next(500));
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

        [Fact]
        public void Can_I_Get_Sms_List_With_DateSentComparation()
        {
            var conditions = new SmsMessageListOptions();
            conditions.DateSent = new DateTime(2012, 8, 3);
            conditions.DateSentComparison = ComparisonType.GreaterThanOrEqualTo;

            var smsListWithCondition = Client.GetSmsMessages(conditions);

            foreach (var sms in smsListWithCondition.SmsMessages)
            {
                Console.WriteLine("sms sid : {0} date: {1}", sms.Sid, sms.DateSent);
            }

            Assert.NotNull(smsListWithCondition);
        }
    }
}

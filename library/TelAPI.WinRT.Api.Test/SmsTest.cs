using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class SmsTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_And_Send_Sms()
        {
            var random = new Random();
            var newSms = await Client.SendSmsMessage(PhoneNumberFrom, PhoneNumberTo, "Hello world" + random.Next(500));
            var receivedSms = await Client.GetSmsMessage(newSms.Sid);

            Assert.Equal(newSms.Sid, receivedSms.Sid);
        }

        [Fact]
        public async Task Can_I_Get_Sms_List()
        {
            var smsList = await Client.GetSmsMessages();

            Assert.NotNull(smsList);            
        }

        [Fact]
        public async Task Can_I_Get_Sms_List_With_Condition()
        {
            var conditions = new SmsMessageListOptions();
            conditions.PageSize = 5;

            var smsListWithCondition = await Client.GetSmsMessages(conditions);

            Assert.NotNull(smsListWithCondition);
            Assert.Equal(conditions.PageSize, smsListWithCondition.PageSize);
        }

        [Fact]
        public async Task Can_I_Get_Sms_List_With_DateSentComparation()
        {
            var conditions = new SmsMessageListOptions();
            conditions.DateSent = new DateTime(2012, 8, 3);
            conditions.DateSentComparison = ComparisonType.GreaterThanOrEqualTo;
            conditions.PageSize = 200;

            var smsListWithCondition = await Client.GetSmsMessages(conditions);

            foreach (var sms in smsListWithCondition.SmsMessages)
            {
                Debug.WriteLine("sms sid : {0} date: {1}", sms.Sid, sms.DateSent);
            }

            Assert.NotNull(smsListWithCondition);
        }
    }
}

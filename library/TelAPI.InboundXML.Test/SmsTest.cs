using Xunit;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class SmsTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Sms()
        {
            var response = new Response();
            response.Sms("Hello from inbound :)", PhoneNumberToDial, PhoneNumberToDial);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Sms_With_Attributes()
        {
            var response = new Response();
            response.Sms("Hello from inbound :)", PhoneNumberToDial, PhoneNumberToDial, null, HttpMethod.POST, null);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

    }
}

using Xunit;
using TelAPI.InboundXML.Element;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class SipTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Dial_With_Sip()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial).Sip("sip-address"));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Dial_With_Sip_With_Attributes()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial).Sip("sip-address", "123", null, HttpMethod.GET));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

    }
}

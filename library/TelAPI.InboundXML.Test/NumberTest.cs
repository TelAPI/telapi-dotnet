using Xunit;
using TelAPI.InboundXML.Element;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class NumberTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Dial_With_Number()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial).Number("123", "456", null, HttpMethod.POST));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

    }
}

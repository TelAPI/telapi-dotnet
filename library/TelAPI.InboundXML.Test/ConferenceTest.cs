using Xunit;
using TelAPI.InboundXML.Element;
using TelAPI.InboundXML.Enum;


namespace TelAPI.InboundXML.Test
{
    public class ConferenceTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Conference_With_Dial()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial).Conference("conference"));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Conference_With_Attributes_With_Dial()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial).Conference("conference", true, true,
                true, false, 10, null, HttpMethod.GET, null, null, null, null, null, null, false));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

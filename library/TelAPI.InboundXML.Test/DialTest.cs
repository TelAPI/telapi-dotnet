using Xunit;
using TelAPI.InboundXML.Element;
using TelAPI.InboundXML.Option;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class DialTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Dial()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Dial_With_Options()
        {
            var response = new Response();
            var options = new DialOptions();

            options.Value = PhoneNumberToDial;
            options.Action = "http://www.action-url.com";
            options.HangupOnStar = false;
            options.HideCallerId = true;
            options.Method = HttpMethod.GET;

            response.Dial(Dial.Create(options));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Dial_With_Attributes()
        {
            var response = new Response();
            response.Dial(Dial.Create(PhoneNumberToDial,
                null, null, 10, null, null, null, false, null, null,
                null, true, null, true, null, null, null));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

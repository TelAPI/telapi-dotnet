using Xunit;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class SayTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Say()
        {
            var response = new Response();
            response.Say("Hello from InboundXML!");

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Say_With_Attributes()
        {
            var response = new Response();
            response.Say("Hello from women voice", Voice.man, 10);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Multiple_Say()
        {
            var response = new Response();
            response.Say("Hello").Say("From").Say("Inbound XML", null, 10);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

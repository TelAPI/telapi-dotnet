using Xunit;

namespace TelAPI.InboundXML.Test
{
    public class HangupTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Hangup()
        {
            var response = new Response();
            response.Hangup();

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Hangup_With_Attributes()
        {
            var response = new Response();
            response.Hangup(10);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

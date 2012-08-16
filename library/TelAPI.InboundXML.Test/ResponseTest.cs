using Xunit;

namespace TelAPI.InboundXML.Test
{
    public class ResponseTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Response()
        {
            var response = new Response();

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

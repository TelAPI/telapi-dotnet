using Xunit;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class RedirectTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Redirect()
        {
            var response = new Response();
            response.Redirect("http://www.redirect-url.com");

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Redirect_With_Attributes()
        {
            var response = new Response();
            response.Redirect("http://www.redirect-url.com", HttpMethod.POST);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

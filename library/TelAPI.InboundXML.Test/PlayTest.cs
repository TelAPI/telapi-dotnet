using Xunit;

namespace TelAPI.InboundXML.Test
{
    public class PlayTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Play()
        {
            var response = new Response();
            response.Play("http://www.audio-url.com");

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Play_With_Attributes()
        {
            var response = new Response();
            response.Play("http://www.audio-url.com", 10);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }


    }
}

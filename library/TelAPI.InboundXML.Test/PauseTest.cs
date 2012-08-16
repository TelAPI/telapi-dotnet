using Xunit;

namespace TelAPI.InboundXML.Test
{
    public class PauseTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Pause()
        {
            var response = new Response();
            response.Pause();

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Pause_With_Attributes()
        {
            var response = new Response();
            response.Pause(5);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

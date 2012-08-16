using Xunit;
using TelAPI.InboundXML.Element;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class GatherTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Gather()
        {
            var response = new Response();
            response.Gather(Gather.Create("http://www.action-url.com"));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Gather_With_Attributes()
        {
            var response = new Response();
            response.Gather(Gather.Create("http://www.action-url.com", null, 10, "#", 10));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Gather_With_Play()
        {
            var response = new Response();
            response.Gather(Gather.Create("http://www.action-url.com").Play("http://www.audio-url.com", 10));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Gather_With_Pause()
        {
            var response = new Response();
            response.Gather(Gather.Create("http://www.action-url.com").Pause());

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Gather_With_Say()
        {
            var response = new Response();
            response.Gather(Gather.Create("http://www.action-url.com").Say("Hello", Voice.man, null));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

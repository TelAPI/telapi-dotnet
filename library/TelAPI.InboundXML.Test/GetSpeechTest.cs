using Xunit;
using TelAPI.InboundXML.Element;

namespace TelAPI.InboundXML.Test
{
    public class GetSpeechTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_GetSpeech()
        {
            var response = new Response();
            response.GetSpeech(GetSpeech.Create("http://www.grammar-url.com", "http://www.action-url.com"));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_GetSpeech_With_Attributes()
        {
            var response = new Response();
            response.GetSpeech(GetSpeech.Create("http://www.grammar-url.com", "http://www.action-url.com", null, 10, true));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_GetSpeech_With_Play()
        {
            var response = new Response();
            response.GetSpeech(GetSpeech.Create("http://www.grammar-url.com", "http://www.action-url.com").Play("http://www.audio-url.com", null));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_GetSpeech_With_Pause()
        {
            var response = new Response();
            response.GetSpeech(GetSpeech.Create("http://www.grammar-url.com", "http://www.action-url.com").Pause());

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_GetSpeech_With_Say()
        {
            var response = new Response();
            response.GetSpeech(GetSpeech.Create("http://www.grammar-url.com", "http://www.action-url.com").Say("Hello", null, null));

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

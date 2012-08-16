using Xunit;
using TelAPI.InboundXML.Option;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class RecordTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Record()
        {
            var response = new Response();
            response.Record("http://www.action-url.com");

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Record_With_Options()
        {
            var response = new Response();
            var options = new RecordOptions();

            options.FileFormat = RecordingFileFormat.wav;
            options.FinishOnKey = "*";
            options.Timeout = 10;

            response.Record(options);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Record_With_Attributes()
        {
            var response = new Response();
            response.Record("http://www.action-url.com", null,
                10, "*", 10, true, 
                null, false, false, null);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

using Xunit;
using TelAPI.InboundXML.Enum;

namespace TelAPI.InboundXML.Test
{
    public class RejectTest : TelAPIBaseTest
    {
        [Fact]
        public void Can_I_Generate_Reject()
        {
            var response = new Response();
            response.Reject();

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }

        [Fact]
        public void Can_I_Generate_Reject_With_Attributes()
        {
            var response = new Response();
            response.Reject(RejectReason.busy);

            Assert.True(IsValidInboundXML(response.CreateXml()));
        }
    }
}

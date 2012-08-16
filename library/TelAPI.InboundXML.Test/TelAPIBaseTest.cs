using System;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Linq;

namespace TelAPI.InboundXML.Test
{
    public class TelAPIBaseTest
    {
        public XmlSchemaSet Schemas { get; set; }
        public const string PhoneNumberToDial = "+123456789";

        public TelAPIBaseTest()
        {
            Schemas = new XmlSchemaSet();
            Schemas.Add("", XmlReader.Create("InboundXML.xsd"));
        }

        public bool IsValidInboundXML(string xml)
        {
            Console.WriteLine(xml);
            var document = XDocument.Parse(xml);            
            
            var valid = true;
            document.Validate(Schemas, (o, e) => { valid = false; });

            return valid;
        }
    }
}

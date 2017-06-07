using System.IO;
using System.Xml.Serialization;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.DocumentSerialization
{
    public class XmlDocumentSerializer: ObjectSerializer<Document>
    {
        private readonly XmlSerializer formatter;

        public XmlDocumentSerializer(string fileExtension, XmlSerializer formatter) : base(fileExtension)
        {
            this.formatter = formatter;
        }

        public override void Serialize(Stream stream, Document obj)
        {
            formatter.Serialize(stream, obj);
        }
    }
}
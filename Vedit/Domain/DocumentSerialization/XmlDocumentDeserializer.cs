using System.IO;
using System.Xml.Serialization;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.DocumentSerialization
{
    public class XmlDocumentDeserializer: ObjectDeserializer<Document>
    {
        private readonly XmlSerializer formatter;

        public XmlDocumentDeserializer(string fileExtension, XmlSerializer formatter) : base(fileExtension)
        {
            this.formatter = formatter;
        }

        public override Document Deserialize(Stream stream)
        {
            return (Document)formatter.Deserialize(stream);
        }
    }
}
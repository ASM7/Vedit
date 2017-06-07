using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.DocumentSerialization
{
    public class BinaryDocumentSerializer : ObjectSerializer<Document>
    {
        private readonly BinaryFormatter formatter;

        public BinaryDocumentSerializer(string fileExtension, BinaryFormatter formatter) : base(fileExtension)
        {
            this.formatter = formatter;
        }

        public override void Serialize(Stream stream, Document obj)
        {
            formatter.Serialize(stream, obj);
        }
    }
}
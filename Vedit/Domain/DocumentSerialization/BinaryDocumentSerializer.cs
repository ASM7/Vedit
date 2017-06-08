using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.DocumentSerialization
{
    public class BinaryDocumentSerializer : BinarySerializer<Document>, IFileTypeProvider
    {
        public string FileExtension => ".bin";
        public string TypeDescription => "Binary vector graphics";

        public BinaryDocumentSerializer(BinaryFormatter formatter) : base(formatter)
        {
        }
    }
}
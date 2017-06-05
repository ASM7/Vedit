using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class BinDocumentFormatter : IFormatter<Document>
    {
        private readonly BinaryFormatter formatter;

        public BinDocumentFormatter(BinaryFormatter formatter)
        {
            this.formatter = formatter;
        }

        public IEnumerable<byte> Serialize(Document obj)
        {
            var stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            return stream.GetBuffer();
        }

        public Document Deserialize(IEnumerable<byte> bytes)
        {
            return (Document) formatter.Deserialize(new MemoryStream(bytes.ToArray()));
        }
    }
}
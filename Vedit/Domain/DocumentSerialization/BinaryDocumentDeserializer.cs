using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Vedit.Infrastructure;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.Serealization
{
    public class BinaryDocumentDeserializer : ObjectDeserializer<Document>
    {
        private readonly BinaryFormatter formatter;

        public BinaryDocumentDeserializer(string fileExtension, BinaryFormatter formatter) : base(fileExtension)
        {
            this.formatter = formatter;
        }

        public override Document Deserialize(Stream stream)
        {
            return (Document)formatter.Deserialize(stream);
        }
    }
}
using System.IO;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.DocumentSerialization
{
    public class BitmapRenderer : ISerializer<Document>, IFileTypeProvider
    {
        public string FileExtension => ".bmp";
        public string TypeDescription => "Bitmap graphics";

        public void Serialize(Stream stream, Document obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.IO;

namespace Vedit.Infrastructure.Serialization
{
    public abstract class ObjectDeserializer<T> : IObjectFileReader<T>
    {
        public string FileExtension { get; }

        public ObjectDeserializer(string fileExtension)
        {
            FileExtension = fileExtension;
        }

        public T ReadObject(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                return Deserialize(stream);
            }
        }

        public abstract T Deserialize(Stream stream);
    }
}
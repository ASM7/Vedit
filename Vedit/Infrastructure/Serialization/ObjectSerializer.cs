using System.IO;

namespace Vedit.Infrastructure.Serialization
{
    public abstract class ObjectSerializer<T> : IObjectFileWriter<T>
    {
        public string FileExtension { get; }

        public ObjectSerializer(string fileExtension)
        {
            FileExtension = fileExtension;
        }

        public void WriteObject(string fileName, T obj)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                Serialize(stream, obj);
            }
        }

        public abstract void Serialize(Stream stream, T obj);
    }
}
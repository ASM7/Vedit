using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Vedit.Infrastructure.Serialization
{
    public class BinarySerializer<T> : ISerializer<T>, IDeserializer<T>
    {
        private readonly BinaryFormatter formatter;
        public BinarySerializer(BinaryFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void Serialize(Stream stream, T obj)
        {
            formatter.Serialize(stream, obj);
        }

        public T Deserialize(Stream stream)
        {
            return (T) formatter.Deserialize(stream);
        }
    }
}
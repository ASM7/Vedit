using System.IO;

namespace Vedit.Infrastructure.Serialization
{
    public static class SerializationExtensions
    {
        public static void WriteObject<T>(this ISerializer<T> serializer, string fileName, T obj)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, obj);
            }
        }

        public static T ReadObject<T>(this IDeserializer<T> deserializer, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                return deserializer.Deserialize(stream);
            }
        }
    }
}
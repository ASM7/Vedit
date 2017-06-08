using System.IO;

namespace Vedit.Infrastructure.Serialization
{
    public interface IDeserializer<out T>
    {
        T Deserialize(Stream stream);
    }
}
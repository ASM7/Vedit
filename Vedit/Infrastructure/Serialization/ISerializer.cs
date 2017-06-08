using System.IO;

namespace Vedit.Infrastructure.Serialization
{
    public interface ISerializer<in T>
    {
        void Serialize(Stream stream, T obj);
    }
}
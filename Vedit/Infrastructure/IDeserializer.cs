using System.Collections.Generic;

namespace Vedit.Infrastructure
{
    public interface IDeserializer<out T>
    {
        T Deserialize(IEnumerable<byte> bytes);
    }
}
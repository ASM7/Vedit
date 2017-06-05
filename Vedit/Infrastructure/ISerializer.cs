using System.Collections.Generic;

namespace Vedit.Infrastructure
{
    public interface ISerializer<in T>
    {
        IEnumerable<byte> Serialize(T obj);
    }
}
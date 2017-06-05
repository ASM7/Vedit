namespace Vedit.Infrastructure
{
    public interface IFormatter<T>: ISerializer<T>, IDeserializer<T>
    {
        
    }
}
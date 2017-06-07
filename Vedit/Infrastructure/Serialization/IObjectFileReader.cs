namespace Vedit.Infrastructure.Serialization
{
    public interface IObjectFileReader<out T> : IFileExtensionProvider
    {
        T ReadObject(string fileName);
    }
}
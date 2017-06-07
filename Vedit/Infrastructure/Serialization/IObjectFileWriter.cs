namespace Vedit.Infrastructure.Serialization
{
    public interface IObjectFileWriter<in T> : IFileExtensionProvider
    {
        void WriteObject(string fileName, T obj);
    }
}
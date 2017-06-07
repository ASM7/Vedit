namespace Vedit.Infrastructure.Serialization
{
    public interface IObjectFileWriter<in T>
    {
        void WriteObject(string fileName, T obj);
        string FileExtension { get; }
    }
}
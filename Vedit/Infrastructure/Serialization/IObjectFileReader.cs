namespace Vedit.Infrastructure.Serialization
{
    public interface IObjectFileReader<out T>
    {
        T ReadObject(string fileName);
        string FileExtension { get; }
    }
}
namespace Vedit.Infrastructure.Serialization
{
    public interface IFileTypeProvider
    {
        string FileExtension { get; }
        string TypeDescription { get; }
    }
}
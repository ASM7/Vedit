namespace Vedit.UI
{
    public interface IMenuAction
    {
        string Category { get; }
        string Name { get; }
        void Perform();
    }
}
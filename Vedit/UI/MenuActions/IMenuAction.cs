namespace Vedit.UI.MenuActions
{
    public interface IMenuAction
    {
        string Category { get; }
        string Name { get; }
        void Perform();
    }
}
using System.Drawing;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    public interface IEditor
    {
        Document Document { get; set; }
        Bitmap Draw(ImageSettings settings);
        void MoveShape(IShape shape, Vector offset);
        void SelectShape(IShape shape);
        void ClearSelection();
        IShape FindShape(Vector point);
        void InteractWithShape(IShape shape, Vector start, Vector end);
    }
}

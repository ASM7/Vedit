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
        ClickContext FindShape(Vector point);
        void InteractWithShape(ClickContext clickContext, Vector offset);
    }
}

using System.Drawing;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    public interface IEditor
    {
        Document Document { get; }
        Bitmap Draw(ImageSettings settings);
        void MoveShape(IShape shape, Vector offset);
    }
}

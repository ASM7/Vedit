using System.Drawing;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    interface IEditor
    {
        Document Document { get; }
        Bitmap Draw(ImageSettings settings);
        void MoveShape(IShape shape, Vector offset);
    }
}

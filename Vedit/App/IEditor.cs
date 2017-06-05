using System.Drawing;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    interface IEditor
    {
        IShape CreateShape<TShape>() 
            where TShape : IShape, new();
        Bitmap Draw(ImageSettings settings);
        void MoveShape(Vector start, Vector end);
        IShape FindShape(Vector point);
    }
}

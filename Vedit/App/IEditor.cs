using System.Drawing;
using Vedit.Domain;

namespace Vedit.App
{
    interface IEditor
    {
        IShape CreateShape<TShape>() 
            where TShape : IShape, new();
        Bitmap Draw(int width, int height);
    }
}

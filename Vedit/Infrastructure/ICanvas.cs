using System.Drawing;

namespace Vedit.Infrastructure
{
    public interface ICanvas
    {
        Graphics StartDrawing();
        Bitmap GetImage();
    }
}
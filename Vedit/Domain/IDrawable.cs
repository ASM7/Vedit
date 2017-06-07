using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public interface IDrawable
    {
        Vector Position { get; set; }
        Size BoundingRectSize { get; set; }
        float Angle { get; set; }

        void Paint(Bitmap bitmap);
        void Paint(Graphics graphics);
    }
}
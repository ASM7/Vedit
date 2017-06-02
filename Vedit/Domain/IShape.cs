using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public interface IShape
    {
        Vector Position { get; set; }
        Size BoundingRectSize { get; set; }
        double Angle { get; set; }

        void Paint(ICanvas canvas);
    }
}
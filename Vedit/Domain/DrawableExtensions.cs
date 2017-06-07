using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public static class DrawableExtensions
    {
        public static bool ContainsPoint(this IDrawable drawable, Vector point)
        {
            var rectangle = new Rectangle(point.ToDrawingPoint(), drawable.BoundingRectSize);
            return rectangle.Contains(point.ToDrawingPoint());
        }
    }
}
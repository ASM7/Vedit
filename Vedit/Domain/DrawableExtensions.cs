using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public static class DrawableExtensions
    {
        public static Rectangle GetBoundingRectangle(this IDrawable drawable)
        {
            return new Rectangle(drawable.Position.ToDrawingPoint(), drawable.BoundingRectSize);
        }

        public static bool ContainsPoint(this IDrawable drawable, Vector point)
        {
            return drawable.GetBoundingRectangle().Contains(point.ToDrawingPoint());
        }
    }
}
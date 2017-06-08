using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public static class DrawableExtensions
    {
        public static bool ContainsPoint(this IDrawable drawable, Vector point)
        {
            var rect = new Rectangle(drawable.Position.ToDrawingPoint(), drawable.BoundingRectSize);
            var center = drawable.Position +
                         0.5 * new Vector(drawable.BoundingRectSize.Width, drawable.BoundingRectSize.Height);
            return rect.Contains(point.Rotate(center, -drawable.Angle.ToRadians()).ToDrawingPoint());
        }
    }
}
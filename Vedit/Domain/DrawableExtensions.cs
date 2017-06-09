using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public static class DrawableExtensions
    {
        public static bool ContainsPoint(this IDrawable drawable, Vector point)
        {
            return drawable.ContainsPoint(drawable, point);
        }

        public static bool ContainsPoint(this IDrawable drawable, IDrawable parentDrawable, Vector point)
        {
            var rect = new RectangleF(drawable.Position.ToDrawingPoint(), drawable.BoundingRectSize);
            var center = parentDrawable.Position +
                         0.5 * new Vector(parentDrawable.BoundingRectSize.Width, parentDrawable.BoundingRectSize.Height);
            return rect.Contains(point.Rotate(center, -parentDrawable.Angle.ToRadians()).ToDrawingPoint());
        }
    }
}
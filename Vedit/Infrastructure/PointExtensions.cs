using System.Drawing;

namespace Vedit.Infrastructure
{
    public static class PointExtensions
    {
        public static Vector ToVector(this Point point)
        {
            return new Vector(point.X, point.Y);
        }

        public static double DistanceTo(this Point from, Point to)
        {
            return (from.ToVector() - to.ToVector()).Length;
        }
    }
}
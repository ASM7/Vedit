using System.Drawing;

namespace Vedit.Infrastructure
{
    public static class PointExtensions
    {
        public static Vector ToVector(this Point point)
        {
            return new Vector(point);
        }

        public static double DistanceTo(this Point from, Point to)
        {
            return (new Vector(from) - new Vector(to)).Length;
        }
    }
}
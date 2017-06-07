using System.Drawing;

namespace Vedit.Infrastructure
{
    public static class VectorExtensions
    {
        public static Point ToDrawingPoint(this Vector vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }
    }
}
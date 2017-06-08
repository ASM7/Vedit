using System;
using System.Drawing;

namespace Vedit.Infrastructure
{
    public static class VectorExtensions
    {
        public static Point ToDrawingPoint(this Vector vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }

        public static Size ToIntegerSize(this Vector vector)
        {
            return new Size((int)vector.X, (int)vector.Y);
        }

        public static Vector CoordinateMultipliply(this Vector v1, Vector v2)
        {
            return new Vector(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector Rotate(this Vector vector, Vector basePoint, double angle)
        {
            var delta = vector - basePoint;
            var rotateMatrix = new[]
            {
                new Vector(Math.Cos(angle), -Math.Sin(angle)),
                new Vector(Math.Sin(angle), Math.Cos(angle))
            };
            return new Vector(basePoint.X + rotateMatrix[0] * delta, basePoint.Y + rotateMatrix[1] * delta);
        }
    }
}
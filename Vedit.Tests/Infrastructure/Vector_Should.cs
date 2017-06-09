using System;
using FluentAssertions;
using NUnit.Framework;
using Vedit.Infrastructure;

namespace Vedit.Tests.Infrastructure
{
    [TestFixture]
    internal class Vector_Should
    {
        [TestCase(3, 4, ExpectedResult = 5, Description = "when ordinary vector")]
        [TestCase(0, 4, ExpectedResult = 4, Description = "when x is zero")]
        [TestCase(3, 0, ExpectedResult = 3, Description = "when y is zero")]
        [TestCase(0, 0, ExpectedResult = 0, Description = "when zero-vector")]
        public double HasCorrectLength(double x, double y)
        {
            var vector = new Vector(x, y);
            return vector.Length;
        }

        private double[] UnpackVector(Vector v)
        {
            return new[] {v.X, v.Y};
        }

        [TestCase(2, 5, 9, 8, ExpectedResult = new[] {11, 13}, Description = "when ordinary vectors")]
        [TestCase(2, 5, 0, 0, ExpectedResult = new[] {2, 5}, Description = "with zero vectors")]
        [TestCase(-2, 5, 9, -8, ExpectedResult = new[] {7, -3}, Description = "with negative coordinates in vectors")]
        public double[] ReturnCorrectSum(int x1, int y1, int x2, int y2)
        {
            return UnpackVector(new Vector(x1, y1) + new Vector(x2, y2));
        }

        [TestCase(20, 50, 9, 8, ExpectedResult = new[] {11, 42}, Description = "when ordinary vectors")]
        [TestCase(2, 5, 0, 0, ExpectedResult = new[] {2, 5}, Description = "with zero vector")]
        [TestCase(0, 0, 7, 3, ExpectedResult = new[] {-7, -3}, Description = "when minuend is zero")]
        [TestCase(2, 5, -5, 8, ExpectedResult = new[] {7, -3}, Description = "when subtrahend has negative coordinate")]
        public double[] ReturnCorrectDifference(int x1, int y1, int x2, int y2)
        {
            return UnpackVector(new Vector(x1, y1) - new Vector(x2, y2));
        }

        [TestCase(3, 7, 2, ExpectedResult = new[] {6, 14}, Description = "when scalar is integer")]
        [TestCase(2, 5, 0, ExpectedResult = new[] {0, 0}, Description = "when scalar is zero")]
        [TestCase(2, 5, 0.5, ExpectedResult = new[] {1, 2.5}, Description = "when scalar is real")]
        public double[] ReturnCorrectProductWithScalar(int x1, int y1, double scalar)
        {
            return UnpackVector(new Vector(x1, y1)*scalar);
        }

        [TestCase(2, 3, 10, 20, ExpectedResult = 80, Description = "when ordinary case")]
        [TestCase(2, 3, 0, 0, ExpectedResult = 0, Description = "when one vector is zero")]
        [TestCase(2, 3, 3, -2, ExpectedResult = 0, Description = "when orthonal vectors")]
        public double ReturnCorrectScalarProduct(double x1, double y1, double x2, double y2)
        {
            return new Vector(x1, y1) * new Vector(x2, y2);
        }

        [TestCase(2, 1, 0, 0, Math.PI / 2, new double[] {-1, 2}, Description = "when base is zero")]
        [TestCase(2, 0, 1, 3, Math.PI / 2, new double[] { 4, 4 }, Description = "when base is non-zero")]
        [TestCase(1, 3, 1, 3, Math.PI / 2, new double[] { 1, 3 }, Description = "when equal to base")]
        [TestCase(-1, -2, 0, 0, Math.PI, new double[] { 1, 2 }, Description = "when negative coordinates")]
        public void RotatesCorrectly(double x, double y, double baseX, double baseY, double angle, double[] expected)
        {
            var eps = 10e-7;
            UnpackVector(new Vector(x, y).Rotate(new Vector(baseX, baseY), angle))
                .Should()
                .Equal(expected, (a, e) => Math.Abs(a - e) < eps);
        }

        [TestCase(2, 3, 4, 5, ExpectedResult = new[] { 8, 15 }, Description = "when ordinary case")]
        [TestCase(0, 0, 3, 4, ExpectedResult = new[] { 0, 0 }, Description = "when one vector is zero")]
        public double[] MultipliedByEachCoordinateCorrectly(double x1, double y1, double x2, double y2)
        {
            return UnpackVector(new Vector(x1, y1).CoordinateMultiply(new Vector(x2, y2)));
        }
    }
}
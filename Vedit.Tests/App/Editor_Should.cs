using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Vedit.App;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.Tests.App
{
    [TestFixture]
    public class Editor_Should
    {
        private IShape shape;

        [SetUp]
        public void SetUp()
        {
            shape = A.Fake<IShape>();
        }
        
        [Test]
        public void CalculateNewSizeCorrectly_ForOneCoordinateImpact()
        {
            shape.Position = Vector.Zero;
            shape.BoundingRectSize = new SizeF(10, 20);
            shape.Angle = 0;
            Editor.CalcNewSize(new Vector(1, 0), shape, new Vector(5, 10))
                .Should().Be(new SizeF(15, 20));
        }

        [Test]
        public void CalculateNewSizeCorrectly_ForTwoCoordinatesImpact()
        {
            shape.Position = Vector.Zero;
            shape.BoundingRectSize = new SizeF(10, 20);
            shape.Angle = 0;
            Editor.CalcNewSize(new Vector(1, -1), shape, new Vector(5, 10))
                .Should().Be(new SizeF(15, 10));
        }

        [Test]
        public void CalculateNewSizeCorrectly_WhenRotatedShape()
        {
            shape.Position = Vector.Zero;
            shape.BoundingRectSize = new SizeF(10, 20);
            shape.Angle = 30;
            Editor.CalcNewSize(new Vector(1, 0), shape, new Vector(0, 10))
                .Should().Be(new SizeF(15, 20));
        }

        [Test]
        public void CalculateNewPositionCorrectly_ForOneCoordinateImpact()
        {
            shape.Position = Vector.Zero;
            shape.BoundingRectSize = new SizeF(10, 20);
            shape.Angle = 0;
            Editor.CalcNewPosition(new Vector(1, 0), shape, new SizeF(15, 20), new Vector(5, 10))
                .Should().Be(Vector.Zero);
        }

        [Test]
        public void CalculateNewPositionCorrectly_ForTwoCoordinatesImpact()
        {
            shape.Position = Vector.Zero;
            shape.BoundingRectSize = new SizeF(10, 20);
            shape.Angle = 0;
            Editor.CalcNewPosition(new Vector(1, -1), shape, new SizeF(5, 10), new Vector(5, 10))
                .Should().Be(new Vector(5, 10));
        }

        [Test]
        public void CalculateNewPositionCorrectly_WhenRotatedShape()
        {
            shape.Position = Vector.Zero;
            shape.BoundingRectSize = new SizeF(10, 20);
            shape.Angle = 90;
            Editor.CalcNewPosition(new Vector(-1, 0), shape, new SizeF(20, 20), new Vector(10, 0))
                .Should().Be(new Vector(-5, 0));
        }
    }
}
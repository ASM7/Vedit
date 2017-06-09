using System.Drawing;
using FakeItEasy;
using NUnit.Framework;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.Tests.Domain
{
    [TestFixture]
    public class Drawable_Should
    {
        private IDrawable drawable;

        [SetUp]
        public void SetUp()
        {
            drawable = A.Fake<IDrawable>();
        }
        
        [TestCase(0, 0, 10, 20, 0, 2, 2, ExpectedResult = true, Description = "when parallel to axis and contains")]
        [TestCase(0, 0, 10, 20, 0, 15, 5, ExpectedResult = false, Description = "when parallel to axis and not contains")]
        [TestCase(0, 0, 10, 20, 90, 2, 2, ExpectedResult = false, Description = "when rotated and not contains")]
        [TestCase(0, 0, 10, 20, 90, 15, 5, ExpectedResult = true, Description = "when rotated and contains")]
        [TestCase(-5, -5, 5, 5, 0, -1, -3, ExpectedResult = true, Description = "when negative coordinates and contains")]
        public bool TestContainingPointCorrectly(double x, double y, float w, float h, float angle, double pX, double pY)
        {
            drawable.Position = new Vector(x, y);
            drawable.BoundingRectSize = new SizeF(w, h);
            drawable.Angle = angle;
            return drawable.ContainsPoint(new Vector(pX, pY));
        }
    }
}
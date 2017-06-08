using System.Drawing;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App.SelectionPrimitives
{
    public class KeyPoint : DrawableObject, ISelectionPrimitive
    {
        public readonly Vector OffsetPositionVector;
        public readonly Vector OffsetSizeVector;

        public KeyPoint(Vector offsetPositionVector, Vector offsetSizeVector)
        {
            BoundingRectSize = new Size(10, 10);
            OffsetPositionVector = offsetPositionVector;
            OffsetSizeVector = offsetSizeVector;
        }

        protected override void PaintStraight(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Blue, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
        }
    }
}
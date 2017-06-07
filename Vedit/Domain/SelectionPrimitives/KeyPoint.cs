using System.Drawing;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.Domain.SelectionPrimitives
{
    public class KeyPoint : DrawableObject, ISelectionPrimitive
    {
        public readonly Vector OffsetPositionVector;
        public readonly Vector OffsetSizeVector;

        public KeyPoint(IShape parentShape, Vector offsetPositionVector, Vector offsetSizeVector)
            :base()
        {
            OffsetPositionVector = offsetPositionVector;
            OffsetSizeVector = offsetSizeVector;
        }

        protected override void PaintStraight(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Blue, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
        }
    }
}
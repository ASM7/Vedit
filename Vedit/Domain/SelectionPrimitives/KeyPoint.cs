using System.Drawing;

namespace Vedit.Domain.SelectionPrimitives
{
    public class KeyPoint : DrawableObject, ISelectionPrimitive
    {
        protected override void PaintStraight(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Blue, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
        }
    }
}
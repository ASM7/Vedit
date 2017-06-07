using System.Drawing;

namespace Vedit.Domain.SelectionPrimitives
{
    public class KeyPoint : DrawableObject, ISelectionPrimitive
    {
        protected override void PaintStraight(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Blue, this.GetBoundingRectangle());
        }
    }
}
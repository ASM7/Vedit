using System.Drawing;
using System.Drawing.Drawing2D;
using Vedit.Domain;

namespace Vedit.App.SelectionPrimitives
{
    public class SelectionFrame: DrawableObject, ISelectionPrimitive
    {
        private static readonly Pen pen;

        static SelectionFrame()
        {
            pen = new Pen(Color.Black);
            pen.DashPattern = new[] {2f};
            pen.DashStyle = DashStyle.Dash;
        }

        protected override void PaintStraight(Graphics graphics)
        {
            graphics.DrawRectangle(pen, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
        }
    }
}
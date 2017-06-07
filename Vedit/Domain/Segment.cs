using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class Segment: DrawableObject, IShape
    {
        public float LineWidth { get; set; }
        public Color Color { get; set; }
        
        protected override void PaintStraight(Graphics graphics)
        {
            var pen = new Pen(Color, LineWidth);
            graphics.DrawLine(
                pen,
                Position.ToDrawingPoint(),
                (Position + new Vector(0, BoundingRectSize.Width)).ToDrawingPoint());
        }
    }
}
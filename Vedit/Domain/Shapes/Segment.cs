using System;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain.Shapes
{
    [Serializable]
    public class Segment: DrawableObject, IShape
    {
        public float LineWidth { get; set; } = 10;
        public Color Color { get; set; } = Color.Black;
        
        protected override void PaintStraight(Graphics graphics)
        {
            var pen = new Pen(Color, LineWidth);
            graphics.DrawLine(
                pen,
                Position.ToDrawingPoint(),
                (Position + new Vector(BoundingRectSize.Width, 0)).ToDrawingPoint());
        }
    }
}
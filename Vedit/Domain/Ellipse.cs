using System;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class Ellipse : DrawableObject, IShape
    {
        public float LineWidth { get; set; } = 7;
        public Color LineColor { get; set; } = Color.DeepPink;
        public Color FillColor { get; set; } = Color.CornflowerBlue;
        
        protected override void PaintStraight(Graphics graphics)
        {
            var brush = new SolidBrush(FillColor);
            var pen = new Pen(LineColor, LineWidth);
            var rectangle = new Rectangle(Position.ToDrawingPoint(), BoundingRectSize);
            graphics.FillEllipse(brush, rectangle);
            graphics.DrawEllipse(pen, rectangle);
        }
    }
}
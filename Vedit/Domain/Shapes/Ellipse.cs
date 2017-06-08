using System;
using System.Drawing;

namespace Vedit.Domain.Shapes
{
    [Serializable]
    public class Ellipse : DrawableObject, IShape
    {
        public float LineWidth { get; set; } = 1;
        public Color LineColor { get; set; } = Color.Black;
        public Color FillColor { get; set; } = Color.DodgerBlue;
        
        protected override void PaintStraight(Graphics graphics)
        {
            var brush = new SolidBrush(FillColor);
            var pen = new Pen(LineColor, LineWidth);
            graphics.FillEllipse(brush, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
            graphics.DrawEllipse(pen, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
        }
    }
}
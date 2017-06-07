using System;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain.Shapes
{
    [Serializable]
    public class Ellipse : DrawableObject, IShape
    {
        public float LineWidth { get; set; } = 7;
        public Color LineColor { get; set; } = Color.DeepPink;
        public Color FillColor { get; set; } = Color.CornflowerBlue;
        
        protected override void PaintStraight(Graphics graphics)
        {
            var brush = new SolidBrush(FillColor);
            var pen = new Pen(LineColor, LineWidth);
            graphics.FillEllipse(brush, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
            graphics.DrawEllipse(pen, 0, 0, BoundingRectSize.Width, BoundingRectSize.Height);
        }
    }
}
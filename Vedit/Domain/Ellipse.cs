using System;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class Ellipse : IShape
    {
        public Vector Position { get; set; }
        public Size BoundingRectSize { get; set; } = new Size(150, 100);
        public double Angle { get; set; }
        public float LineWidth { get; set; } = 7;
        public Color LineColor { get; set; } = Color.DeepPink;
        public Color FillColor { get; set; } = Color.CornflowerBlue;

        public void Draw(ICanvas canvas)
        {
            var brush = new SolidBrush(FillColor);
            var pen = new Pen(LineColor, LineWidth);
            using (var graphics = canvas.StartDrawing())
            {
                var rectangle = new Rectangle(Position.ToDrawingPoint(), BoundingRectSize);
                graphics.FillEllipse(brush, rectangle);
                graphics.DrawEllipse(pen, rectangle);
            }
        }
    }
}
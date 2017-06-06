using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class Segment: IShape
    {
        public Vector Position { get; set; }
        public Size BoundingRectSize { get; set; }
        public double Angle { get; set; }
        public float LineWidth { get; set; }
        public Color Color { get; set; }

        public void Draw(ICanvas canvas)
        {
            var pen = new Pen(Color, LineWidth);
            using (var graphics = canvas.StartDrawing())
            {
                graphics.DrawLine(
                    pen,
                    Position.ToDrawingPoint(),
                    (Position + new Vector(0, BoundingRectSize.Width)).ToDrawingPoint());
            }
        }
    }
}
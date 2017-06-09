using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.App.SelectionPrimitives;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class ShapeSelection : DrawableObject
    {
        public ShapeSelection(IShape shape)
        {
            this.shape = shape;
        }

        public List<KeyPoint> CreatePoints(Vector offset)
        {
            var points = new List<KeyPoint>();
            for (var x = 0; x <= 2; x++)
                for (var y = 0; y <= 2; y++)
                {
                    if (x != 0 && y != 0 && x != 2 && y != 2)
                        continue;
                    var sizeVector = new Vector(x == 2 ? 1 : 0, y == 2 ? 1 : 0);
                    if (x == 0)
                        sizeVector = new Vector(-1, sizeVector.Y);
                    if (y == 0)
                        sizeVector = new Vector(sizeVector.X, -1);
                    var point = new KeyPoint(sizeVector);
                    var offsetToPointCenter = point.BoundingRectSize.OffsetToCenter();
                    point.Position = offset + new Vector(x, y).CoordinateMultiply(shape.BoundingRectSize.OffsetToCenter()) - offsetToPointCenter;
                    points.Add(point);
                }
            return points;
        }

        public readonly IShape shape;

        public override void Paint(Bitmap bitmap)
        {
            Angle = shape.Angle;
            Position = shape.Position;
            BoundingRectSize = shape.BoundingRectSize;
            base.Paint(bitmap);
        }
        
        protected override void PaintStraight(Graphics graphics)
        {
            var frame = new SelectionFrame();
            frame.BoundingRectSize = shape.BoundingRectSize;
            frame.Paint(graphics);
            foreach (var point in CreatePoints(Vector.Zero))
                point.Paint(graphics);
        }
    }
}

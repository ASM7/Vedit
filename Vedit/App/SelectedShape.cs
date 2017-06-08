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
    class SelectedShape : DrawableObject
    {
        public SelectedShape(IShape shape)
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
                    var positionVector = new Vector(Convert.ToInt32(x == 0), Convert.ToInt32(y == 0));
                    var sizeVector = new Vector(Convert.ToInt32(x == 2), Convert.ToInt32(y == 2));
                    if (positionVector.X == 1)
                        sizeVector = new Vector(-1, sizeVector.Y);
                    if (positionVector.Y == 1)
                        sizeVector = new Vector(sizeVector.X, -1);
                    var point = new KeyPoint(positionVector, sizeVector);
                    var offsetToPointCenter = point.BoundingRectSize.OffsetToCenter();
                    point.Position = offset + new Vector(x, y).CoordinateMultipliply(shape.BoundingRectSize.OffsetToCenter()) - offsetToPointCenter;
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

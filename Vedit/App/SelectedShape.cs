﻿using System;
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
            for (int x = 0; x <= 2; x++)
                for (int y = 0; y <= 2; y++)
                {
                    if (x == 1 && y == 1)
                        continue;
                    var positionVector = new Vector(Convert.ToInt32(x == 0), Convert.ToInt32(y == 0));
                    var sizeVector = new Vector(Convert.ToInt32(x == 2), Convert.ToInt32(y == 2));
                    if (positionVector.X == 1)
                        sizeVector = new Vector(-1, sizeVector.Y);
                    if (positionVector.Y == 1)
                        sizeVector = new Vector(sizeVector.X, -1);
                    var point = new KeyPoint(positionVector, sizeVector);
                    point.Position = new Vector(offset.X + x * shape.BoundingRectSize.Width / 2,offset.Y+ y * shape.BoundingRectSize.Height / 2);
                    points.Add(point);
                }
            return points;
        }

        public readonly IShape shape;
        
        protected override void PaintStraight(Graphics graphics)
        {
            Angle = shape.Angle;
            Position = shape.Position;
            foreach (var point in CreatePoints(Vector.Zero))
                point.Paint(graphics);
            var frame = new SelectionFrame();
            frame.BoundingRectSize = shape.BoundingRectSize;
            frame.Paint(graphics);
        }
    }
}

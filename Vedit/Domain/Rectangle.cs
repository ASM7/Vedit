using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class Rectangle : CompoundShape
    {
        public Rectangle()
        {
            var segmentSize = new Size(1, 0);
            var angle90 = Math.PI/2;
            elements = new[]
            {
                new Segment() {Position = new Vector(0, 0), BoundingRectSize = segmentSize, Angle = 0},
                new Segment() {Position = new Vector(1, 0), BoundingRectSize = segmentSize, Angle = angle90},
                new Segment() {Position = new Vector(1, 1), BoundingRectSize = segmentSize, Angle = angle90*2},
                new Segment() {Position = new Vector(0, 1), BoundingRectSize = segmentSize, Angle = angle90*3}
            };
        }
    }
}
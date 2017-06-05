using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    // TODO proportional resize
    public abstract class CompoundShape : IShape
    {
        public Vector Position { get; set; }
        public Size BoundingRectSize { get; set; }
        public double Angle { get; set; }

        protected IShape[] elements = {};

        public void Paint(ICanvas canvas)
        {
            foreach (var element in elements)
            {
                element.Paint(canvas);
            }
        }
    }
}
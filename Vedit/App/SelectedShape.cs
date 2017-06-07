using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.Domain;
using Vedit.Domain.SelectionPrimitives;
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

        private IShape shape;
        
        protected override void PaintStraight(Graphics graphics)
        {
            var frame = new SelectionFrame();
            frame.Paint(graphics);
            for (int x = 0; x <= 2; x++)
                for (int y= 0; y <= 2; y++)
                {
                    if (x == 1 && y == 1)
                        continue;
                    var circle = new KeyPoint();
                    circle.Position = new Vector(Position.X + x * BoundingRectSize.Width, Position.Y + y * BoundingRectSize.Height);
                    circle.Paint(graphics);
                }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class Painter : IPainter
    {
        private ImageSettings imageSettings;

        public Painter(ImageSettings imageSettings)
        {
            this.imageSettings = imageSettings;
        }

        public void Draw(Bitmap bitmap, IEnumerable<IDrawable> drawables)
        {
            foreach (var shape in drawables)
            {
                var size = shape.BoundingRectSize;
                var canvas = new Canvas { Image = new Bitmap(size.Width, size.Height) };
                shape.Draw(canvas);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(canvas.GetImage(), shape.Position.ToDrawingPoint());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class Painter : IPainter
    {
        public void Draw(Bitmap bitmap, IEnumerable<IDrawable> drawables)
        {
            foreach (var drawable in drawables)
            {
                drawable.Paint(bitmap);
            }
        }
    }
}

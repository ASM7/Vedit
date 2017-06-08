using System.Collections.Generic;
using System.Drawing;
using Vedit.App;

namespace Vedit.Domain
{
    public class Painter : IPainter
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

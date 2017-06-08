using System.Collections.Generic;
using System.Drawing;

namespace Vedit.Domain
{
    public interface IPainter
    {
        void Draw(Bitmap bitmap, IEnumerable<IDrawable> drawables);
    }
}

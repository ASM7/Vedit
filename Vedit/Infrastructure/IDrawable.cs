using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedit.Infrastructure
{
    public interface IDrawable
    {
        Vector Position { get; set; }
        Size BoundingRectSize { get; set; }
        double Angle { get; set; }
        void Draw(ICanvas canvas);
    }
}

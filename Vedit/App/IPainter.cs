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
    interface IPainter
    {
        void Draw(Bitmap bitmap, IEnumerable<IShape> shapes);
    }
}

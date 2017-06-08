using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedit.Infrastructure
{
    public static class SizeExtension
    {
        public static Size Abs(this Size size)
        {
            return new Size(Math.Abs(size.Width), Math.Abs(size.Height));
        }

        public static Vector OffsetToCenter(this Size size)
        {
            return new Vector(size.Width / 2.0, size.Height / 2.0);
        }
    }
}

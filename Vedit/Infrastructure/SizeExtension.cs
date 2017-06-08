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
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.Application
{
    interface IApplication
    {
        IShape CreateShape<TShape>() 
            where TShape : IShape, new();
        Bitmap Draw(int width, int height);
    }
}

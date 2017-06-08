using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.App.SelectionPrimitives;
using Vedit.Domain.Shapes;

namespace Vedit.App
{
    public class ClickContext
    {
        public readonly IShape Shape;
        public readonly KeyPoint KeyPoint;

        public ClickContext(IShape shape, KeyPoint keyPoint)
        {
            Shape = shape;
            KeyPoint = keyPoint;
        }
    }
}

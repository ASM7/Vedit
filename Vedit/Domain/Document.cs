using System.Collections.Generic;
using System.Drawing;

namespace Vedit.Domain
{
    public class Document
    {
        public Document(Size canvasSize)
        {
            CanvasSize = canvasSize;
            Shapes = new List<IShape>();
        }

        public List<IShape> Shapes { get; }
        public Size CanvasSize { get; set; }
    }
}
using System;
using System.Drawing;
using Vedit.App;
using Vedit.Domain;

namespace Vedit.UI
{
    class ShapeButton<TShape> : IToolButton
        where TShape : IShape, new()
    {
        public Bitmap GetImage(Size size)
        {
            var result =  new Bitmap(size.Width, size.Height);
            var shape = new TShape();
            shape.BoundingRectSize = size;
            using (var g = Graphics.FromImage(result))
            {
                
            }
            return result;
        }

        public void OnClick(Editor editor)
        {
            throw new NotImplementedException();
        }

    }
}
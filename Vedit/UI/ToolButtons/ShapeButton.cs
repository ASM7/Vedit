using System.Drawing;
using Vedit.App;
using Vedit.Domain.Shapes;

namespace Vedit.UI.ToolButtons
{
    public class ShapeButton<TShape> : IToolButton
        where TShape : IShape, new()
    {
        public Bitmap GetImage(Size size)
        {
            var result =  new Bitmap(size.Width, size.Height);
            var shape = new TShape();
            shape.BoundingRectSize = size;
            shape.Paint(result);
            return result;
        }

        public void OnClick(Editor editor)
        {
            editor.Document.CreateShape<TShape>();
        }

    }
}
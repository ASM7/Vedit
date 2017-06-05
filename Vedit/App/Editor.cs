using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class Editor : IEditor
    {
        private List<IShape> shapes;
        private ICanvasFactory canvasFactory;

        public Editor(ICanvasFactory canvasFactory)
        {
            shapes = new List<IShape>();
            this.canvasFactory = canvasFactory;
        }

        public IShape CreateShape<TShape>() 
            where TShape : IShape, new()
        {
            var shape = new TShape();
            shape.Position = new Vector(0, 0);
            shapes.Add(shape);
            return shape;
        }

        public Bitmap Draw(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            foreach (var shape in shapes)
            {
                var canvas = canvasFactory.CreateCanvas();
                shape.Paint(canvas);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(canvas.Image, shape.Position.ToDrawingPoint());
                }
            }
            return bitmap;
        }
    }
}

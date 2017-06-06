using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class Editor : IEditor
    {
        private List<IShape> shapes;

        public Editor()
        {
            shapes = new List<IShape>();
        }

        public IShape CreateShape<TShape>() 
            where TShape : IShape, new()
        {
            var shape = new TShape();
            shape.Position = new Vector(0, 0);
            shapes.Add(shape);
            return shape;
        }

        public Bitmap Draw(ImageSettings settings)
        {
            Console.WriteLine(shapes.Count);
            var bitmap = new Bitmap(settings.Width, settings.Height);
            foreach (var shape in shapes)
            {
                var size = shape.BoundingRectSize;
                var canvas = new Canvas {Image = new Bitmap(size.Width, size.Height)};
                shape.Paint(canvas);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(canvas.GetImage(), shape.Position.ToDrawingPoint());
                }
            }
            return bitmap;
        }

        public void MoveShape(IShape shape, Vector offset)
        {
            shape.Position += offset;
        }

        public IShape FindShape(Vector point)
        {
            throw new System.NotImplementedException();
        }
    }
}

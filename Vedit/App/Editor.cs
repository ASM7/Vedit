using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class Editor : IEditor
    {
        private IPainter painter;
        private Document document;

        public Editor(IPainter painter, Document document)
        {
            this.painter = painter;
            this.document = document;
        }

        public IShape CreateShape<TShape>() 
            where TShape : IShape, new()
        {
            var shape = new TShape();
            shape.Position = new Vector(0, 0);
            document.Shapes.Add(shape);
            return shape;
        }

        public Bitmap Draw(ImageSettings settings)
        {
            var bitmap = new Bitmap(settings.Width, settings.Height);
            painter.Draw(bitmap, document.Shapes);
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

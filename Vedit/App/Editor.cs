using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class Editor : IEditor
    {
        public Document Document { get; }
        private IPainter painter;
        private HashSet<SelectedShape> selected;

        public Editor(IPainter painter, Document document)
        {
            this.painter = painter;
            Document = document;
            selected = new HashSet<SelectedShape>();
        }

        public Bitmap Draw(ImageSettings settings)
        {
            var bitmap = new Bitmap(settings.Width, settings.Height);
            painter.Draw(bitmap, Document.Shapes);
            return bitmap;
        }

        public void MoveShape(IShape shape, Vector offset)
        {
            shape.Position += offset;
        }

        public void SelectShape(IShape shape)
        {
            selected.Add(new SelectedShape(shape));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    public class Editor : IEditor
    {
        public Document Document
        {
            get { return document; }
            set
            {
                document = value;
                selectedShapes.Clear();
            }
        }
        private Document document;

        private IPainter painter;
        private HashSet<SelectedShape> selectedShapes;

        public Editor(IPainter painter, Document document)
        {
            this.painter = painter;
            this.document = document;
            selectedShapes = new HashSet<SelectedShape>();
        }

        public Bitmap Draw(ImageSettings settings)
        {
            var bitmap = new Bitmap(settings.Width, settings.Height);
            painter.Draw(bitmap, Document.Shapes);
            painter.Draw(bitmap, selectedShapes);
            return bitmap;
        }

        public void MoveShape(IShape shape, Vector offset)
        {
            shape.Position += offset;
        }

        public void SelectShape(IShape shape)
        {
            selectedShapes.Add(new SelectedShape(shape));
        }

        public void ClearSelection()
        {
            selectedShapes = new HashSet<SelectedShape>();
        }

        public void InteractWithShape(IShape shape, Vector start, Vector end)
        {
            shape.Position += end - start;
            //var selected = TryFindSelectedShape(shape);
            //if (selected == null)
            //{
            //    shape.Position += end - start;
            //}
            //else
            //{
            //    foreach (var point in )
            //}
        }

        private SelectedShape TryFindSelectedShape(IShape shape)
        {
            foreach (var selectedShape in selectedShapes)
                if (selectedShape.shape.Equals(shape))
                    return selectedShape;
            return null;
        }
    }
}

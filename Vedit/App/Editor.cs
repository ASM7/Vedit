using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Vedit.Domain;
using Vedit.Domain.SelectionPrimitives;
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
            selectedShapes.Clear();
        }

        public void InteractWithShape(ClickContext clickContext, Vector offset)
        {
            var shape = clickContext.Shape;
            var selected = FindSelectedShape(shape);
            if (selected == null)
            {
                shape.Position += offset;
            }
            else
            {
                var startPoint = clickContext.KeyPoint;
                if (startPoint != null)
                {
                    shape.Position += new Vector(startPoint.OffsetPositionVector.X * offset.X, startPoint.OffsetPositionVector.Y * offset.Y);
                    shape.BoundingRectSize += new Size((int)(startPoint.OffsetSizeVector.X * offset.X), (int)(startPoint.OffsetSizeVector.Y * offset.Y));
                }
                else
                {
                    shape.Position += offset;
                }
            }
        }

        private SelectedShape FindSelectedShape(IShape shape)
        {
            return selectedShapes.FirstOrDefault(selectedShape => selectedShape.shape == shape);
        }

        private KeyPoint FindKeyPoint(IEnumerable<KeyPoint> keyPoints, Vector point)
        {
            return keyPoints.FirstOrDefault(keyPoint => keyPoint.ContainsPoint(point));
        }

        public ClickContext FindShape(Vector point)
        {
            foreach (var selected in selectedShapes)
            {
                var keyPoint = FindKeyPoint(selected.CreatePoints(), point);
                if (keyPoint != null)
                {
                    return new ClickContext(selected.shape, keyPoint);
                }
            }
                
            return new ClickContext(Document.FindShape(point), null);
        }

        public void FixSize(IShape shape)
        {
            if (shape.BoundingRectSize.Width < 0)
                shape.Position += new Vector(shape.BoundingRectSize.Width, 0);
            if (shape.BoundingRectSize.Height < 0)
                shape.Position += new Vector(0, shape.BoundingRectSize.Height);
            shape.BoundingRectSize = new Size(Math.Abs(shape.BoundingRectSize.Width), Math.Abs(shape.BoundingRectSize.Height));
        }
    }
}

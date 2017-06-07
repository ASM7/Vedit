using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain;
using Vedit.Domain.SelectionPrimitives;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    public class Editor : IEditor
    {
        public Document Document { get; }
        private IPainter painter;
        private HashSet<SelectedShape> selectedShapes;

        public Editor(IPainter painter, Document document)
        {
            this.painter = painter;
            Document = document;
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
            var selected = TryFindSelectedShape(shape);
            var delta = end - start;
            if (selected == null)
            {
                shape.Position += delta;
            }
            else
            {
                var points = selected.CreatePoints();
                var startPoint = FindKeyPoint(points, start);
                if (startPoint != null)
                {
                    shape.Position += new Vector(startPoint.OffsetPositionVector.X * delta.X, startPoint.OffsetPositionVector.Y * delta.Y);
                    shape.BoundingRectSize += new Size((int)(startPoint.OffsetSizeVector.X * delta.X), (int)(startPoint.OffsetSizeVector.Y * delta.Y));
                }
                else
                {
                    shape.Position += delta;
                }
            }
        }

        private SelectedShape TryFindSelectedShape(IShape shape)
        {
            foreach (var selectedShape in selectedShapes)
                if (selectedShape.shape == shape)
                    return selectedShape;
            return null;
        }

        private KeyPoint FindKeyPoint(IEnumerable<KeyPoint> keyPoints, Vector point)
        {
            foreach (var keyPoint in keyPoints)
            {
                if (keyPoint.ContainsPoint(point))
                {
                    return keyPoint;
                }
            }   
            return null;
        }

        public IShape FindShape(Vector point)
        {
            foreach (var selected in selectedShapes)
                if (FindKeyPoint(selected.CreatePoints(), point) != null)
                {
                    return selected.shape;
                }
            return Document.FindShape(point);
        }
    }
}

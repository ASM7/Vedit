using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Vedit.App.SelectionPrimitives;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.App
{
    public class Editor
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
        private HashSet<ShapeSelection> selectedShapes;

        public Editor(IPainter painter, Document document)
        {
            this.painter = painter;
            this.document = document;
            selectedShapes = new HashSet<ShapeSelection>();
        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(Document.ImageSettings.Width, Document.ImageSettings.Height);
            painter.Draw(bitmap, Document.Shapes);
            painter.Draw(bitmap, selectedShapes);
            return bitmap;
        }

        public void SelectShape(IShape shape)
        {
            ClearSelection();
            selectedShapes.Add(new ShapeSelection(shape));
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
                InteractWithSelected(clickContext, offset);
            }
        }

        private void InteractWithSelected(ClickContext clickContext, Vector offset)
        {
            var shape = clickContext.Shape;
            var startPoint = clickContext.KeyPoint;
            if (startPoint != null)
            {
                var newSize = CalcNewSize(startPoint.SizeImpact, shape, offset);
                var newPosition = CalcNewPosition(startPoint.SizeImpact, shape, newSize, offset);
                shape.BoundingRectSize = newSize;
                shape.Position = newPosition;
            }
            else
            {
                shape.Position += offset;
            }
        }

        private ShapeSelection FindSelectedShape(IShape shape)
        {
            return selectedShapes.FirstOrDefault(selectedShape => selectedShape.shape == shape);
        }

        private KeyPoint FindKeyPoint(IDrawable parent, IEnumerable<KeyPoint> keyPoints, Vector point)
        {
            return keyPoints.FirstOrDefault(keyPoint => keyPoint.ContainsPoint(parent, point));
        }

        public void RemoveShape(IShape shape)
        {
            document.Shapes.Remove(shape);
            selectedShapes.RemoveWhere(s => s.shape == shape);
        }

        public ClickContext FindShape(Vector point)
        {
            foreach (var selected in selectedShapes.Reverse())
            {
                var keyPoint = FindKeyPoint(selected, selected.CreatePoints(selected.shape.Position), point);
                if (keyPoint != null)
                    return new ClickContext(selected.shape, keyPoint);
            }
            return new ClickContext(Document.FindShape(point), null);
        }

        public void InvertNegativeSize(IShape shape)
        {
            if (shape.BoundingRectSize.Width < 0)
                shape.Position += new Vector(shape.BoundingRectSize.Width, 0);
            if (shape.BoundingRectSize.Height < 0)
                shape.Position += new Vector(0, shape.BoundingRectSize.Height);
            shape.BoundingRectSize = shape.BoundingRectSize.Abs();
        }

        public static SizeF CalcNewSize(Vector sizeImpact, IShape oldShape, Vector offset)
        {
            var rotatedOffset = offset.Rotate(Vector.Zero, -oldShape.Angle.ToRadians());
            return oldShape.BoundingRectSize + sizeImpact.CoordinateMultiply(rotatedOffset).ToSizeF();
        }

        public static Vector CalcNewPosition(Vector sizeImpact, IShape oldShape, SizeF newSize, Vector offset)
        {
            var sizeImpactAbs = new Vector(
                Math.Abs(sizeImpact.X),
                Math.Abs(sizeImpact.Y));
            var limitedOffset = offset
                .Rotate(Vector.Zero, -oldShape.Angle.ToRadians())
                .CoordinateMultiply(sizeImpactAbs)
                .Rotate(Vector.Zero, oldShape.Angle.ToRadians());
            var currentCenter = oldShape.Position + oldShape.BoundingRectSize.OffsetToCenter();
            var newCenter = currentCenter + 0.5 * limitedOffset;
            return newCenter - newSize.OffsetToCenter();
        }
    }
}

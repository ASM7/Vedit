using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    [Serializable]
    public class Document
    {
        public Document() { }

        public Document(ImageSettings imageSettings)
        {
            ImageSettings = imageSettings;
            Shapes = new List<IShape>();
        }

        public List<IShape> Shapes { get; }
        public ImageSettings ImageSettings { get; }

        public IShape CreateShape<TShape>()
            where TShape : IShape, new()
        {
            var shape = new TShape {Position = new Vector(0, 0)};
            Shapes.Add(shape);
            return shape;
        }

        public IShape FindShape(Vector point)
        {
            return Shapes.Find(s => s.ContainsPoint(point));
        }
    }
}
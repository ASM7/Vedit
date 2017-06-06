using System;
using System.Collections.Generic;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    public class Document
    {
        public Document(ImageSettings imageSettings)
        {
            ImageSettings = imageSettings;
            Shapes = new List<IShape>();
        }

        public List<IShape> Shapes { get; }
        public ImageSettings ImageSettings { get; }

        public IShape FindShape(Vector point)
        {
            throw new NotImplementedException();
        }
    }
}
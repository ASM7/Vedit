using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vedit.Domain;
using Vedit.Infrastructure;

namespace Vedit.App
{
    class SelectedShape : IDrawable
    {
        public SelectedShape(IShape shape)
        {
            this.shape = shape;
        }

        private IShape shape;
        Vector IDrawable.Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        Size IDrawable.BoundingRectSize
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        float IDrawable.Angle
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Paint(ICanvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}

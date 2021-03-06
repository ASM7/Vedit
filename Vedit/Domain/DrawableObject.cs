﻿using System;
using System.Drawing;
using Vedit.Infrastructure;

namespace Vedit.Domain
{
    [Serializable]
    public abstract class DrawableObject : IDrawable
    {
        public Vector Position { get; set; } = Vector.Zero;
        public SizeF BoundingRectSize { get; set; } = new Size(100, 100);
        public float Angle { get; set; }

        public virtual void Paint(Bitmap bitmap)
        {
            using (var graphics = Graphics.FromImage(bitmap))
                Paint(graphics);
        }

        public void Paint(Graphics graphics)
        {
            graphics.TranslateTransform(Position);

            var centerOffset = new Vector(BoundingRectSize.Width, BoundingRectSize.Height) * 0.5;
            graphics.TranslateTransform(centerOffset);
            graphics.RotateTransform(Angle);
            graphics.TranslateTransform(-1 * centerOffset);

            PaintStraight(graphics);

            graphics.TranslateTransform(centerOffset);
            graphics.RotateTransform(-Angle);
            graphics.TranslateTransform(-1 * centerOffset);
            graphics.TranslateTransform(-1 * Position);
        }

        protected abstract void PaintStraight(Graphics graphics);
    }
}
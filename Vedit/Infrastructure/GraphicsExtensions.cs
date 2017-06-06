using System.Drawing;

namespace Vedit.Infrastructure
{
    public static class GraphicsExtensions
    {
        public static void TranslateTransform(this Graphics graphics, Vector offset)
        {
            graphics.TranslateTransform((float)offset.X, (float)offset.Y);
        }
    }
}
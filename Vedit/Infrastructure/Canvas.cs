using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vedit.Infrastructure
{
    public class Canvas : PictureBox
    {
        public Size GetImageSize()
        {
            FailIfNotInitialized();
            return Image.Size;
        }

        public Graphics StartDrawing()
        {
            FailIfNotInitialized();
            return Graphics.FromImage(Image);
        }

        public void SaveImage(string fileName)
        {
            FailIfNotInitialized();
            Image.Save(fileName);
        }

        private void FailIfNotInitialized()
        {
            if (Image == null)
                throw new InvalidOperationException("Call Canvas.RecreateImage before other method call!");
        }
    }
}
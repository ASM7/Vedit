using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Vedit.App;
using Vedit.Infrastructure.Serialization;

namespace Vedit.Domain.DocumentSerialization
{
    public class BitmapRenderer : ISerializer<Document>, IFileTypeProvider
    {
        private readonly IPainter painter;
        public string FileExtension => ".bmp";
        public string TypeDescription => "Bitmap graphics";

        public BitmapRenderer(IPainter painter)
        {
            this.painter = painter;
        }

        public void Serialize(Stream stream, Document obj)
        {
            var bitmap = new Bitmap(obj.ImageSettings.Width, obj.ImageSettings.Height);
            using (var graphics = Graphics.FromImage(bitmap))
                graphics.Clear(Color.White);
            painter.Draw(bitmap, obj.Shapes);
            bitmap.Save(stream, ImageFormat.Bmp);
        }
    }
}
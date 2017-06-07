using System;
using System.Drawing;
using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;
namespace Vedit.UI
{
    class Gui : Form, IClient
    {
        private readonly IEditor editor;
        private readonly Canvas canvas;
        private readonly ImageSettings imageSettings;

        private Vector mouseDownPoint;

        public Gui(IEditor editor, Canvas canvas, ImageSettings imageSettings)
        {
            this.editor = editor;
            editor.Document.CreateShape<Ellipse>();
            this.canvas = canvas;
            this.imageSettings = imageSettings;
            Text = "Vedit";
            //canvas.Image = new Bitmap(imageSettings.Width, imageSettings.Width);
            canvas.Image = editor.Draw(imageSettings);
            ClientSize = canvas.Image.Size;
            canvas.Dock = DockStyle.Fill;
            canvas.MouseClick += OnCanvasMouseClick;
            canvas.MouseDown += OnCanvasMouseDown;
            Controls.Add(canvas);
        }

        void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Vector(e.X, e.Y);
        }

        void OnCanvasMouseClick(object sender, MouseEventArgs e)
        {
            var mouseClickPoint = new Vector(e.X, e.Y);
            if (mouseDownPoint == null || mouseDownPoint.Equals(mouseClickPoint))
            {
                var shape = editor.Document.FindShape(mouseClickPoint);
                canvas.Image = GetOriginalImage();
                FocusOnShape(shape);
            }
            else
            {
                var shape = editor.Document.FindShape(mouseDownPoint);
                var offset = mouseClickPoint - mouseDownPoint;
                editor.MoveShape(shape, offset);
                canvas.Image = GetOriginalImage();
            }
            Refresh();
            mouseDownPoint = null;
        }

        Bitmap GetOriginalImage()
        {
            return editor.Draw(imageSettings);
        }

        void FocusOnShape(IShape shape)
        {
            
        }

        public void Run()
        {
            Application.Run(this);
        }
    }
}
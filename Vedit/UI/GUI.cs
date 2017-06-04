using System;
using System.Drawing;
using System.Windows.Forms;
using Vedit.Infrastructure;
namespace Vedit.UI
{
    class Gui : Form, IClient
    {
        public Gui(Canvas canvas, ImageSettings imageSettings)
        {
           
            canvas.Image = new Bitmap(imageSettings.Width, imageSettings.Width);
            ClientSize = canvas.Image.Size;
            canvas.Dock = DockStyle.Fill;
            MouseClick += OnMouseClick;
            MouseDown += OnMouseDown;
            Controls.Add(canvas);
        }

        static void OnMouseDown(object sender, MouseEventArgs e)
        {
            
        }


        static void OnMouseClick(object sender, MouseEventArgs e)
        {
            
        }


        public void Run()
        {
            Application.Run(this);
        }
    }
}
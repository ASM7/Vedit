using System;
using System.Drawing;
using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure;
namespace Vedit.UI
{
    class Gui : Form, IClient
    {
        private readonly IEditor editor;
        private readonly PictureBox picture;
        private readonly ImageSettings imageSettings;

        private Vector mousePoint;

        public Gui(IEditor editor, ToolPanel toolPanel, ImageSettings imageSettings)
        {
            this.editor = editor;
            this.imageSettings = imageSettings;

            Text = "Vedit";
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;

            var layoutPanel = new TableLayoutPanel() {AutoSize = true, AutoSizeMode = AutoSizeMode.GrowOnly};
            
            editor.CreateShape<Ellipse>();
            picture = new PictureBox {SizeMode = PictureBoxSizeMode.AutoSize};
            InitPicture(editor.Draw(imageSettings));

            layoutPanel.Controls.Add(toolPanel);
            layoutPanel.SetCellPosition(picture, new TableLayoutPanelCellPosition(0, 0));

            layoutPanel.Controls.Add(picture);
            layoutPanel.SetCellPosition(picture, new TableLayoutPanelCellPosition(1, 0));

            //layoutPanel.Controls.Add(propertiesPanel);
            //layoutPanel.SetCellPosition(picture, new TableLayoutPanelCellPosition(2, 0));

            Controls.Add(layoutPanel);
        }

        void InitPicture(Image image)
        {
            picture.Image = image;
            picture.Dock = DockStyle.Fill;
            picture.MouseClick += OnCanvasMouseClick;
            picture.MouseMove += OnPictureMouseMove;
            picture.MouseDown += OnCanvasMouseDown;
        }

        void OnPaint(object sender, PaintEventArgs e)
        {
            
        }

        void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            //var shape = editor.FindShape(e.Location.ToVector());
            //FocusOnShape(shape);
        }

        void OnPictureMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
            }
            mousePoint = e.Location.ToVector();
        }

        void OnCanvasMouseClick(object sender, MouseEventArgs e)
        {
            var mouseClickPoint = new Vector(e.X, e.Y);
            //if (mouseDownPoint == null || mouseDownPoint.Equals(mouseClickPoint))
            //{
            //    var shape = editor.FindShape(mouseClickPoint);
            //    picture.Image = GetOriginalImage();
            //    FocusOnShape(shape);
            //}
            //else
            //{
            //    var shape = editor.FindShape(mouseDownPoint);
            //    var offset = mouseClickPoint - mouseDownPoint;
            //    editor.MoveShape(shape, offset);
            //    picture.Image = GetOriginalImage();
            //}
            Refresh();
            //mouseDownPoint = null;
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
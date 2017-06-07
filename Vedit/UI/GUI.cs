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

            Paint += (sender, e) => RedrawPicture();
            var layoutPanel = new TableLayoutPanel() {AutoSize = true, AutoSizeMode = AutoSizeMode.GrowOnly};

            picture = new PictureBox {SizeMode = PictureBoxSizeMode.AutoSize};
            InitPicture(editor.Draw(imageSettings));

            toolPanel.AddActionOnClick(RedrawPicture);
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

        void RedrawPicture()
        {
            picture.Image = editor.Draw(imageSettings);
        }


        void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            editor.ClearSelection();
            var shape = editor.Document.FindShape(e.Location.ToVector());
            if (shape != null)
                editor.SelectShape(shape);
        }

        void OnPictureMouseMove(object sender, MouseEventArgs e)
        {
            var start = mousePoint;
            var end = e.Location.ToVector();
            if (e.Button == MouseButtons.Left)
            {
                var shape = editor.Document.FindShape(start);
                if (shape != null)
                    editor.InteractWithShape(shape, start, end);
            }
            mousePoint = end;
        }

        void OnCanvasMouseClick(object sender, MouseEventArgs e)
        {
            var mouseClickPoint = new Vector(e.X, e.Y);

            Refresh();
           
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
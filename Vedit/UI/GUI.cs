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
            var shape = editor.Document.FindShape(e.Location.ToVector());
            editor.SelectShape(shape);
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
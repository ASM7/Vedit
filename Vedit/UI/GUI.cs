using System;
using System.Drawing;
using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;
using Vedit.UI.MenuActions;

namespace Vedit.UI
{
    class Gui : Form, IClient
    {
        private readonly IEditor editor;
        private readonly PictureBox picture;
        private readonly ImageSettings imageSettings;
        private readonly PropertyGrid propertiesPanel;
        private Vector mousePoint;

        public Gui(IEditor editor, ToolPanel toolPanel, ImageSettings imageSettings, IMenuAction[] menuActions)
        {
            this.editor = editor;
            this.imageSettings = imageSettings;

            Text = "Vedit";
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;

            var menu = new MenuStrip();
            menu.Items.AddRange(menuActions.ToMenuItems());
            Controls.Add(menu);

            Paint += (sender, e) => RedrawPicture();
            var layoutPanel = new TableLayoutPanel()
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Location = new Point(0, menu.Bottom)
                };

            picture = new PictureBox { SizeMode = PictureBoxSizeMode.AutoSize };
            InitPicture(editor.Draw(imageSettings));

            toolPanel.AddActionOnClick(RedrawPicture);
            layoutPanel.Controls.Add(toolPanel);
            layoutPanel.SetCellPosition(picture, new TableLayoutPanelCellPosition(0, 0));

            layoutPanel.Controls.Add(picture);
            layoutPanel.SetCellPosition(picture, new TableLayoutPanelCellPosition(1, 0));

            propertiesPanel = new PropertyGrid
            {
                Width = 300,
                Dock = DockStyle.Fill,
                Location = new Point(0, menu.Bottom)
            };
            propertiesPanel.PropertyValueChanged += (sender, e) => RedrawPicture();
            
            layoutPanel.Controls.Add(propertiesPanel);
            layoutPanel.SetCellPosition(propertiesPanel, new TableLayoutPanelCellPosition(2, 0));
            
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
            {
                editor.SelectShape(shape);
                propertiesPanel.SelectedObject = shape;
                propertiesPanel.Show();
            }
            else
            {
                propertiesPanel.Hide();
            }
                
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
                Refresh();
                propertiesPanel.Refresh();
            }
            mousePoint = end;
        }

        void OnCanvasMouseClick(object sender, MouseEventArgs e)
        {
            Refresh();           
        }

        Bitmap GetOriginalImage()
        {
            return editor.Draw(imageSettings);
        }

        public void Run()
        {
            Application.Run(this);
        }
    }
}
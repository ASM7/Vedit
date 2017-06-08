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
        private readonly Editor editor;
        private readonly PictureBox picture;
        private readonly ImageSettings imageSettings;
        private readonly PropertyGrid propertiesPanel;
        private Vector mousePoint;

        public Gui(Editor editor, ToolPanel toolPanel, ImageSettings imageSettings, IMenuAction[] menuActions)
        {
            this.editor = editor;
            this.imageSettings = imageSettings;
            InitializeComponent();
            var menu = CreateMenu(menuActions.ToMenuItems());
            picture = CreatePictureBox(editor.Draw(imageSettings));
            toolPanel.AddActionOnClick(RedrawPicture);
            propertiesPanel = CreatePropertyPanel();
            var layoutPanel = CreateLayoutPanel(new Control[] {toolPanel, picture, propertiesPanel});
            layoutPanel.Location = new Point(0, menu.Bottom);
            Controls.Add(menu);
            Controls.Add(layoutPanel);
        }

        private TableLayoutPanel CreateLayoutPanel(Control[] controls)
        {
            var layoutPanel = new TableLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            for (int i = 0; i < controls.Length; i++)
            {
                layoutPanel.Controls.Add(controls[i]);
                layoutPanel.SetCellPosition(controls[i], new TableLayoutPanelCellPosition(i, 0));
            }
            return layoutPanel;
        }

        private void InitializeComponent()
        {
            Text = "Vedit";
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            Paint += (sender, e) => RedrawPicture();
        }

        PropertyGrid CreatePropertyPanel()
        {
            var panel = new PropertyGrid
            {
                Width = 300,
                Dock = DockStyle.Fill
            };
            panel.PropertyValueChanged += (sender, e) => RedrawPicture();
            return panel;
        }

        MenuStrip CreateMenu(ToolStripItem[] menuItems)
        {
            var menu = new MenuStrip();
            menu.Items.AddRange(menuItems);
            return menu;
        }

        PictureBox CreatePictureBox(Image image)
        {
            var pictureBox = new PictureBox { SizeMode = PictureBoxSizeMode.AutoSize };
            pictureBox.Image = image;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.MouseClick += OnCanvasMouseClick;
            pictureBox.MouseMove += OnPictureMouseMove;
            pictureBox.MouseDown += OnCanvasMouseDown;
            pictureBox.MouseUp += OnCanvasMouseUp;
            return pictureBox;
        }

        private void OnCanvasMouseUp(object sender, MouseEventArgs e)
        {
            if (currentClickContext.Shape != null)
                editor.InvertNegativeSize(currentClickContext.Shape);
        }

        void RedrawPicture()
        {
            picture.Image = editor.Draw(imageSettings);
        }

        private ClickContext currentClickContext;

        void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            currentClickContext = editor.FindShape(e.Location.ToVector());
            var shape = currentClickContext.Shape;
            if (shape != null)
            {
                editor.SelectShape(shape);
                propertiesPanel.SelectedObject = shape;
                propertiesPanel.Show();
            }
            else
            {
                editor.ClearSelection();
                propertiesPanel.Hide();
            }
        }

        void OnPictureMouseMove(object sender, MouseEventArgs e)
        {
            var start = mousePoint;
            var end = e.Location.ToVector();
            if (e.Button == MouseButtons.Left)
            {
                if (currentClickContext.Shape != null)
                    editor.InteractWithShape(currentClickContext, end - start);
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
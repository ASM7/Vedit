using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vedit.App;
using Vedit.Infrastructure;
using Vedit.UI.ToolButtons;

namespace Vedit.UI
{
    class ToolPanel : TableLayoutPanel
    {
        public ToolPanel(IToolButton[] toolButtons, Editor editor, ToolPanelSettings settings)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            Cursor = Cursors.Hand;
            ColumnCount = settings.ColumnCount;
            var buttons = toolButtons.Select(b =>
            {
                var button = new Button();
                button.Click += (sender, e) => b.OnClick(editor);
                button.Size = settings.ButtonSize;
                button.BackgroundImage = b.GetImage(settings.ButtonSize);
                button.BackgroundImageLayout = ImageLayout.Stretch;
                return button;
            }).ToArray();
            Controls.AddRange(buttons);
        }

        public void AddActionOnClick(Action action)
        {
            foreach (var control in Controls)
            {
                if (control is Button)
                {
                    ((Button) control).Click += (sender, e) => action();
                }
            }
        }

    }
}

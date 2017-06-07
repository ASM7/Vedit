using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vedit.App;

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
                var button = new Button {Image = b.GetImage(settings.ButtonSize) };
                button.Click += WrapClick(() => b.OnClick(editor));
                button.Size = settings.ButtonSize;
                return button;
            }).ToArray();
            Controls.AddRange(buttons);
        }

        private static EventHandler WrapClick(Action action)
        {
            return (sender, e) => action();
        }
    }
}

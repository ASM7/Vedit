using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Vedit.UI.MenuActions
{
    // from https://github.com/kontur-csharper/di/blob/master/FractalPainter/Infrastructure/UiActionExtensions.cs

    public static class MenuActionExtensions
    {
        public static ToolStripItem[] ToMenuItems(this IMenuAction[] actions)
        {
            var items = actions.GroupBy(a => a.Category)
                .Select(g => CreateToplevelMenuItem(g.Key, g.ToList()))
                .Cast<ToolStripItem>()
                .ToArray();
            return items;
        }

        private static ToolStripMenuItem CreateToplevelMenuItem(string name, IList<IMenuAction> items)
        {
            var menuItems = items.Select(a => a.ToMenuItem()).ToArray();
            return new ToolStripMenuItem(name, null, menuItems);
        }

        public static ToolStripItem ToMenuItem(this IMenuAction action)
        {
            return
                new ToolStripMenuItem(action.Name, null, (sender, args) => action.Perform())
                {
                    Tag = action
                };
        }
    }
}
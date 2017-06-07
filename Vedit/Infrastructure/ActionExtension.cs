using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedit.Infrastructure
{
    static class ActionExtension
    {
        public static  EventHandler ToEventHandler(this Action action)
        {
            return (sender, e) => action();
        }
    }
}

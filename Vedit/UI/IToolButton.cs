using System.Drawing;
using Vedit.App;

namespace Vedit.UI
{
    internal interface IToolButton
    {
        Bitmap GetImage(Size size);
        void OnClick(Editor editor);
    }
}
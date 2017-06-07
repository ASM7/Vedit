using System.IO;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public class OpenAction : OpenSaveAction<IObjectFileReader<Document>, OpenFileDialog>
    {
        public override string Name => "Открыть";

        public OpenAction(IEditor editor, IObjectFileReader<Document>[] operators) : base(editor, operators)
        {
        }

        protected override void MakeOperation(string fileName, IObjectFileReader<Document> fileOperator)
        {
            editor.Document = fileOperator.ReadObject(fileName);
        }

    }
}
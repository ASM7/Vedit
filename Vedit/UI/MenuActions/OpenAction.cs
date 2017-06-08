using System.IO;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public class OpenAction : FileNameAction<IDeserializer<Document>, OpenFileDialog>
    {
        public override string Name => "Открыть";

        public OpenAction(Editor editor, IDeserializer<Document>[] operators) : base(editor, operators)
        {
        }

        protected override void MakeOperation(string fileName, IDeserializer<Document> fileOperator)
        {
            editor.Document = fileOperator.ReadObject(fileName);
        }

    }
}
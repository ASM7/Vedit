using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public class SaveAction : FileNameAction<ISerializer<Document>, SaveFileDialog>
    {
        public SaveAction(IEditor editor, ISerializer<Document>[] operators) : base(editor, operators)
        {
        }

        public override string Name => "Сохранить как...";

        protected override void MakeOperation(string fileName, ISerializer<Document> fileOperator)
        {
            fileOperator.WriteObject(fileName, editor.Document);
        }
    }
}
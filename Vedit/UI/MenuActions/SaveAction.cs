using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public class SaveAction : OpenSaveAction<IObjectFileWriter<Document>, SaveFileDialog>
    {
        public SaveAction(IEditor editor, IObjectFileWriter<Document>[] operators) : base(editor, operators)
        {
        }

        public override string Name => "Сохранить как...";

        protected override void MakeOperation(string fileName, IObjectFileWriter<Document> fileOperator)
        {
            fileOperator.WriteObject(fileName, editor.Document);
        }
    }
}
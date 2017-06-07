using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public abstract class OpenSaveAction<TFileOperator, TDialog> : IMenuAction
        where TFileOperator: IFileExtensionProvider
        where TDialog: FileDialog, IDisposable, new ()
    {
        private readonly TFileOperator[] operators;
        protected readonly IEditor editor;

        public OpenSaveAction(IEditor editor, TFileOperator[] operators)
        {
            this.editor = editor;
            this.operators = operators;
        }

        public string Category => "Файл";
        public abstract string Name { get; }

        public void Perform()
        {
            using (var dialog = new TDialog())
            {
                dialog.Filter = operators.Cast<IFileExtensionProvider>().BuildDialogFilterString();
                if (dialog.ShowDialog() != DialogResult.OK) return;
                var fileExt = Path.GetExtension(dialog.FileName).Substring(1);
                var fileOperator = operators.FirstOrDefault(w => w.FileExtension == fileExt);
                if (fileOperator == null)
                    return;
                MakeOperation(dialog.FileName, fileOperator);
            }
        }

        protected abstract void MakeOperation(string fileName, TFileOperator fileOperator);
    }
}
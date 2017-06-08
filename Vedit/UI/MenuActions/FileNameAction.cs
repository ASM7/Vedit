using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public abstract class FileNameAction<TFileOperator, TDialog> : IMenuAction
        where TDialog: FileDialog, IDisposable, new ()
    {
        protected readonly Editor editor;
        private readonly IFileTypeProvider[] operators;

        public FileNameAction(Editor editor, TFileOperator[] operators)
        {
            this.editor = editor;
            this.operators = operators.Where(op => op is IFileTypeProvider).Cast<IFileTypeProvider>().ToArray();
        }

        public string Category => "Файл";
        public abstract string Name { get; }

        public void Perform()
        {
            using (var dialog = new TDialog())
            {
                dialog.Filter = operators.BuildDialogFilterString();
                if (dialog.ShowDialog() != DialogResult.OK) return;
                var fileExt = Path.GetExtension(dialog.FileName);
                var fileOperator = operators.FirstOrDefault(w => w.FileExtension == fileExt);
                if (fileOperator == null)
                    return;
                MakeOperation(dialog.FileName, (TFileOperator)fileOperator);
            }
        }

        protected abstract void MakeOperation(string fileName, TFileOperator fileOperator);
    }
}
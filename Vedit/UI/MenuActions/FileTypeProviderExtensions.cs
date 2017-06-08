using System.Collections.Generic;
using System.Linq;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public static class FileTypeProviderExtensions
    {
        public static string BuildDialogFilterString(this IEnumerable<IFileTypeProvider> extProviders)
        {
            return string.Join("|",
                extProviders.Select(r => $"{r.TypeDescription} (*{r.FileExtension}) | *{r.FileExtension}"));
        }
    }
}
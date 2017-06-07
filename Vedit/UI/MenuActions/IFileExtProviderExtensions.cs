using System.Collections.Generic;
using System.Linq;
using Vedit.Infrastructure.Serialization;

namespace Vedit.UI.MenuActions
{
    public static class FileExtProviderExtensions
    {
        public static string BuildDialogFilterString(this IEnumerable<IFileExtensionProvider> extProviders)
        {
            return string.Join("|",
                extProviders.Select(r => $"Vector graphics (*.{r.FileExtension}) | *.{r.FileExtension}"));
        }
    }
}
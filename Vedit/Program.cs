using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Activation;
using Vedit.App;
using Vedit.Infrastructure;
using Vedit.UI;

namespace Vedit
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientInit().Run();
        }

        static IClient ClientInit()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IClient>().To<Gui>();
            kernel.Bind<IEditor>().To<Editor>();
            kernel.Bind<ImageSettings>().ToConstant(new ImageSettings {Width = 500, Height = 500});
            return kernel.Get<IClient>();
        }
    }
}

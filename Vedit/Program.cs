using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
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
            kernel.Bind<IClient>().To<Gui>().InSingletonScope();
            kernel.Bind<IEditor>().To<Editor>().InSingletonScope();
            kernel.Bind<IPainter>().To<Painter>();
            kernel.Bind<ImageSettings>().ToConstant(new ImageSettings {Width = 500, Height = 500}).InSingletonScope();
            kernel.Bind(c => c.FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<IToolButton>()
                .BindAllInterfaces());
            return kernel.Get<IClient>();
        }
    }
}

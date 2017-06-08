using System;
using System.Runtime.Serialization.Formatters.Binary;
using Ninject;
using Ninject.Extensions.Conventions;
using Vedit.App;
using Vedit.Domain;
using Vedit.Infrastructure;
using Vedit.Infrastructure.Serialization;
using Vedit.UI;

namespace Vedit
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ClientInit().Run();
        }

        static IClient ClientInit()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IClient>().To<Gui>().InSingletonScope();
            kernel.Bind<Editor>().ToSelf().InSingletonScope();
            kernel.Bind<IPainter>().To<Painter>();
            kernel.Bind<ImageSettings>().ToConstant(new ImageSettings {Width = 500, Height = 500}).InSingletonScope();
            kernel.Bind(c => c.FromThisAssembly()
                .SelectAllClasses()
                .InheritedFromAny(typeof(IToolButton), typeof(IMenuAction), typeof(ISerializer<Document>), typeof(IDeserializer<Document>))
                .BindAllInterfaces());
            kernel.Bind<BinaryFormatter>().ToSelf();
            return kernel.Get<IClient>();
        }
    }
}

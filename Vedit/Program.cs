using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Ninject;
using Ninject.Extensions.Conventions;
using Vedit.App;
using Vedit.Domain;
using Vedit.Domain.Shapes;
using Vedit.Infrastructure;
using Vedit.Infrastructure.Serialization;
using Vedit.UI;
using Vedit.UI.MenuActions;
using Vedit.UI.ToolButtons;

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
                .InheritedFromAny(typeof(IMenuAction), typeof(ISerializer<Document>), typeof(IDeserializer<Document>))
                .BindAllInterfaces());
            foreach (var buttonType in GenerateShapeButtonTypes())
                kernel.Bind<IToolButton>().To(buttonType);
            kernel.Bind<BinaryFormatter>().ToSelf();
            return kernel.Get<IClient>();
        }

        static Type[] GenerateShapeButtonTypes()
        {
            return Assembly.GetAssembly(typeof(Program))
                .GetTypes()
                .Where(t => typeof(IShape).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .Select(t => typeof(ShapeButton<>).MakeGenericType(t))
                .ToArray();
        }
    }
}

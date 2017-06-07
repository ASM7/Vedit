using System;
using System.Runtime.Serialization.Formatters.Binary;
using Ninject;
using Ninject.Extensions.Conventions;
using Vedit.App;
using Vedit.Domain;
using Vedit.Domain.DocumentSerialization;
using Vedit.Domain.Serealization;
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
            kernel.Bind<IEditor>().To<Editor>().InSingletonScope();
            kernel.Bind<IPainter>().To<Painter>();
            kernel.Bind<ImageSettings>().ToConstant(new ImageSettings {Width = 500, Height = 500}).InSingletonScope();
            kernel.Bind(c => c.FromThisAssembly()
                .SelectAllClasses()
                .InheritedFromAny(typeof(IToolButton), typeof(IMenuAction))
                .BindAllInterfaces());
            kernel.Bind<BinaryFormatter>().ToSelf();
            kernel.Bind<IObjectFileReader<Document>>()
                .ToMethod(c => new BinaryDocumentDeserializer("bin", c.Kernel.Get<BinaryFormatter>()));
            kernel.Bind<IObjectFileWriter<Document>>()
                .ToMethod(c => new BinaryDocumentSerializer("bin", c.Kernel.Get<BinaryFormatter>()));
            //kernel.Bind<XmlSerializer>().ToConstant(new XmlSerializer(typeof(Document)));
            //kernel.Bind<IObjectFileReader<Document>>()
            //    .ToMethod(c => new XmlDocumentDeserializer("xml", c.Kernel.Get<XmlSerializer>()));
            //kernel.Bind<IObjectFileWriter<Document>>()
            //    .ToMethod(c => new XmlDocumentSerializer("xml", c.Kernel.Get<XmlSerializer>()));
            return kernel.Get<IClient>();
        }
    }
}

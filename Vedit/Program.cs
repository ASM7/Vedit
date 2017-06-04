using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Vedit.UI;

namespace Vedit
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static IClient ClientInit()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IClient>().To<Gui>();
            return kernel.Get<IClient>();
        }
    }
}

using Autofac;
using PrimeNumbers.BLL;
using PrimeNumbers.BLL.Services.Implementations;
using PrimeNumbers.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNumbers.UI
{
    static class Program
    {
        //TODO: Add DI
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PrimesGenerator>().As<IPrimesGenerator>();
            builder.RegisterType<CycleService>().As<ICycleService>();
            builder.RegisterType<XmlWriter>().As<IXmlWriter>();
            builder.Register(f => new MainForm(f.Resolve<ICycleService>(), f.Resolve<IXmlWriter>())).As<MainForm>();
            using (var container = builder.Build())
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(container.Resolve<MainForm>());
            }
        }
    }
}

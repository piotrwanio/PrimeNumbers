using Autofac;
using AutoMapper;
using PrimeNumbers.BLL;
using PrimeNumbers.BLL.Services.Implementations;
using PrimeNumbers.BLL.Services.Interfaces;
using PrimeNumbers.DTO;
using PrimeNumbers.UI.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeNumbers.Logging;

namespace PrimeNumbers.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
      
            builder.RegisterType<PrimesGenerator>().As<IPrimesGenerator>();
            builder.RegisterType<SegmentedPrimesGenerator>().As<ISegmentedPrimesGenerator>();
            builder.RegisterType<CycleService>().As<ICycleService>();
            builder.RegisterType<XmlWriter>().As<IXmlWriter>();

            builder.RegisterAutomapper();
            builder.RegisterSerilog();

            builder.RegisterType<MainForm>();

            using (var container = builder.Build())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(container.Resolve<MainForm>());
            }
        }
    }
}

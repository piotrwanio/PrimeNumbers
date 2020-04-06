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
            var loadedProfiles = RetrieveProfiles();


            //builder.RegisterTypes(loadedProfiles.ToArray());
            builder.RegisterType<MappingProfile>();
            builder.RegisterType<PrimesGenerator>().As<IPrimesGenerator>();
            builder.RegisterType<CycleService>().As<ICycleService>();
            builder.RegisterType<XmlWriter>().As<IXmlWriter>();

            builder.RegisterType<MainForm>();
            //builder.Register(c => {
            //    return RegisterAutoMapper(c, loadedProfiles);
            //    }).As<IMapper>().InstancePerLifetimeScope(); 

            builder.Register(context => new MapperConfiguration(cfg =>
            {

                cfg.ConstructServicesUsing(context.Resolve);

                //foreach (var profile in loadedProfiles)
                //{
                //    var resolvedProfile = context.Resolve(profile) as Profile;
                //    cfg.AddProfile(resolvedProfile);
                //}
                var resolvedProfile = context.Resolve< MappingProfile>() as Profile;

                cfg.AddProfile(resolvedProfile);
                //cfg.CreateMap<CycleInfo, BasicCycleInfo>()
                //            .ForMember(dest => dest.ComputedBiggestPrime, opt => opt.MapFrom(src => src.Primes.Max()));

                //etc...
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
    
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            });

            using (var container = builder.Build())
            {
            var mapper = RegisterAutoMapper(container, loadedProfiles);
            //builder.RegisterInstance(mapper);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(container.Resolve<MainForm>());
            }
        }

        private static IMapper RegisterAutoMapper(IContainer container, IEnumerable<Type> loadedProfiles)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(container.Resolve);

                foreach (var profile in loadedProfiles)
                {
                    var resolvedProfile = container.Resolve(profile) as Profile;
                    cfg.AddProfile(resolvedProfile);
                }

            });

            return config.CreateMapper();
        }

        /// <summary>
        /// Scan all referenced assemblies to retrieve all `Profile` types.
        /// </summary>
        /// <returns>A collection of <see cref="AutoMapper.Profile"/> types.</returns>
        private static List<Type> RetrieveProfiles()
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Where(a => a.Name.StartsWith("PrimeNumbers.UI.Automapper"));
            var assemblies = assemblyNames.Select(an => Assembly.Load(an));
            var loadedProfiles = ExtractProfiles(assemblies);
            return loadedProfiles;
        }


        private static List<Type> ExtractProfiles(IEnumerable<Assembly> assemblies)
        {
            var profiles = new List<Type>();
            foreach (var assembly in assemblies)
            {
                var assemblyProfiles = assembly.ExportedTypes.Where(type => type.IsSubclassOf(typeof(Profile)));
                profiles.AddRange(assemblyProfiles);
            }
            return profiles;
        }
    }
}

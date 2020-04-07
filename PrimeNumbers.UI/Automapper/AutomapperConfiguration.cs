using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Serilog;

namespace PrimeNumbers.UI.Automapper
{
    public static class AutomapperConfiguration
    {
        public static void RegisterAutomapper(this ContainerBuilder builder)
        {
            var loadedProfiles = RetrieveProfiles();


            builder.RegisterTypes(loadedProfiles.ToArray());

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(context.Resolve);

                foreach (var resolvedProfile in loadedProfiles.Select(profile => context.Resolve(profile) as Profile))
                {
                    cfg.AddProfile(resolvedProfile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();

                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            });
        }

        private static List<Type> RetrieveProfiles()
        {
            var assemblies = new List<Assembly> { Assembly.GetExecutingAssembly() };
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

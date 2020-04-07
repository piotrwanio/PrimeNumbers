using System;
using Autofac;
using Serilog;

namespace PrimeNumbers.Logging
{
    public static class SerilogConfiguration
    {
        public static void RegisterSerilog(this ContainerBuilder builder)
        {
            builder.Register<ILogger>((c, p) => new LoggerConfiguration()
                .WriteTo.RollingFile(
                    AppDomain.CurrentDomain.BaseDirectory.ToString() + "/logs/Log-{Date}.txt")
                .CreateLogger()).SingleInstance();
        }
    }
}

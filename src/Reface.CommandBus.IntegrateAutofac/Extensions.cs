using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace Reface.CommandBus
{
    public static class Extensions
    {
        public static ContainerBuilder RegsiterCommandHandlers(this ContainerBuilder containerBuilder, Assembly assembly)
        {
            Type type = typeof(ICommandHandler);
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(x => type.IsAssignableFrom(x))
                .AsImplementedInterfaces();
            return containerBuilder;
        }
    }
}

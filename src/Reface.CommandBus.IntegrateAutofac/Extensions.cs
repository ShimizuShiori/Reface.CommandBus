using Autofac;
using Reface.CommandBus.Core;
using System;
using System.Linq;
using System.Reflection;

namespace Reface.CommandBus
{
    public static class Extensions
    {
        /// <summary>
        /// 注册运行命令总线所需要的组件
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <returns></returns>
        public static ContainerBuilder RegisterCommandBusComponents(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(AutofacCommandHandlerFactory)).AsImplementedInterfaces();
            containerBuilder.RegisterType(typeof(DefaultCommandBus)).AsImplementedInterfaces();
            return containerBuilder;
        }

        /// <summary>
        /// 以程序集注册所有的命令处理器
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
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

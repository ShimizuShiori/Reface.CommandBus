using Reface.CommandBus.Configuration;
using System;

namespace Reface.CommandBus
{
    public class ConfigurationCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly CommandBusSection section;

        public ConfigurationCommandHandlerFactory() : this("commandBus")
        {

        }

        public ConfigurationCommandHandlerFactory(string sectionName)
        {
            this.section = CommandBusSectionFactory.Get(sectionName);
        }

        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            Type type = typeof(TCommand);
            Type handlerType = typeof(ICommandHandler<>);
            foreach (Handler handler in section.Handlers)
            {
                System.Type b = handler.RealType.GetInterface(handlerType.FullName);
                if (b == null) continue;
                var cmd = b.GetGenericArguments()[0];
                if (cmd != type) continue;
                return (ICommandHandler<TCommand>)Activator.CreateInstance(handler.RealType);
            }
            throw new ApplicationException("未注册的处理器");
        }
    }
}

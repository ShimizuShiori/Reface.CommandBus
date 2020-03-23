using Reface.CommandBus.Configuration;

namespace Reface.CommandBus
{
    public class ConfigurationCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly DefaultCommandHandlerFactory defaultFactory;

        public ConfigurationCommandHandlerFactory() : this("commandBus")
        {

        }

        public ConfigurationCommandHandlerFactory(string sectionName)
        {
            CommandBusSection section = CommandBusSectionFactory.Get(sectionName);
            this.defaultFactory = new DefaultCommandHandlerFactory();
            foreach (Handler handler in section.Handlers)
            {
                this.defaultFactory.Register(handler.RealType);
            }
        }

        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            return this.defaultFactory.Create<TCommand>();
        }
    }
}

namespace Reface.CommandBus
{
    public class DefaultCommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory commandHandlerFactory;

        public DefaultCommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            this.commandHandlerFactory = commandHandlerFactory;
        }

        public object Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = this.commandHandlerFactory.Create<TCommand>();
            return handler.Handler(command);
        }
    }
}

using Reface.CommandBus.Errors;

namespace Reface.CommandBus
{
    public abstract class CommandHandlerFactoryBase : ICommandHandlerFactory
    {
        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            ICommandHandler<TCommand> result;
            if (TryCreate<TCommand>(out result))
                return result;

            throw new CommandHandlerNotFoundException(typeof(TCommand));
        }

        protected abstract bool TryCreate<TCommand>(out ICommandHandler<TCommand> handler)
            where TCommand : ICommand;
    }
}

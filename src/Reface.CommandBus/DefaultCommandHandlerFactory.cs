using System;
using System.Collections.Generic;

namespace Reface.CommandBus
{
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Dictionary<Type, Func<object>> handlerCreators = new Dictionary<Type, Func<object>>();

        public DefaultCommandHandlerFactory Register<TCommand>(Func<ICommandHandler<TCommand>> creator)
            where TCommand : ICommand
        {
            this.handlerCreators[typeof(TCommand)] = creator;
            return this;
        }

        public DefaultCommandHandlerFactory Register<TCommand>(ICommandHandler<TCommand> handler)
            where TCommand : ICommand
        {
            return this.Register<TCommand>(() => handler);
        }

        public DefaultCommandHandlerFactory Register<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>, new()
        {
            return this.Register<TCommand>(() => new THandler());
        }

        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            Func<object> creator;
            if (handlerCreators.TryGetValue(typeof(TCommand), out creator))
                return (ICommandHandler<TCommand>)creator();

            throw new ApplicationException($"没有处理器可以处理此命令 : {typeof(TCommand).FullName}");
        }
    }
}

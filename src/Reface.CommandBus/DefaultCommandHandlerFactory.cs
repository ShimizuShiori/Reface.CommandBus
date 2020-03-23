using Reface.CommandBus.Errors;
using System;
using System.Collections.Generic;

namespace Reface.CommandBus
{
    public class DefaultCommandHandlerFactory : CommandHandlerFactoryBase
    {
        private readonly Dictionary<Type, Func<object>> handlerCreators = new Dictionary<Type, Func<object>>();

        private DefaultCommandHandlerFactory RegisterCreator(Type commandType, Func<object> creator)
        {
            if (handlerCreators.ContainsKey(commandType))
                throw new CommandHandlerAlreadyExistsException(commandType);
            handlerCreators[commandType] = creator;
            return this;
        }

        public DefaultCommandHandlerFactory Register(Type handlerType)
        {
            Type baseType = typeof(ICommandHandler<>);
            Type baseTypeOfHandler = handlerType.GetInterface(baseType.FullName);
            Type commandType = baseTypeOfHandler.GetGenericArguments()[0];
            return this.RegisterCreator(commandType, () => Activator.CreateInstance(handlerType));
        }

        public DefaultCommandHandlerFactory Register<TCommand>(Func<ICommandHandler<TCommand>> creator)
            where TCommand : ICommand
        {
            return this.RegisterCreator(typeof(TCommand), () => creator());
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

        protected override bool TryCreate<TCommand>(out ICommandHandler<TCommand> handler)
        {
            handler = null;
            Func<object> creator;
            if (handlerCreators.TryGetValue(typeof(TCommand), out creator))
            {
                handler = (ICommandHandler<TCommand>)creator();
                return true;
            }
            return false;
        }
    }
}

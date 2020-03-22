using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reface.CommandBus
{
    public class AutofacCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly ILifetimeScope lifetimeScope;
        private readonly Type commandHandlerBareTtypetypeof;

        public AutofacCommandHandlerFactory(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
            this.commandHandlerBareTtypetypeof = typeof(ICommandHandler<>);
        }

        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            Type requiredHandlerCommandType = this.commandHandlerBareTtypetypeof.MakeGenericType(typeof(TCommand));
            IEnumerable<ICommandHandler> commandHandlers = this.lifetimeScope.Resolve<IEnumerable<ICommandHandler>>();
            var result = commandHandlers
                .FirstOrDefault(x => requiredHandlerCommandType.IsAssignableFrom(x.GetType()));

            if (result == null)
                throw new NotImplementedException();

            return (ICommandHandler<TCommand>)result;

        }
    }
}

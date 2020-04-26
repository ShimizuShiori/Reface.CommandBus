using Reface.CommandBus.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;

namespace Reface.CommandBus
{
    public class DefaultCommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory commandHandlerFactory;
        private readonly ConcurrentDictionary<Type, Action<ICommandHandler, ICommand>> cachedTriggers;

        public DefaultCommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            this.commandHandlerFactory = commandHandlerFactory;
            this.cachedTriggers = new ConcurrentDictionary<Type, Action<ICommandHandler, ICommand>>();
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            Type commandType = command.GetType();
            IEnumerable<ICommandHandler> handlers = this.commandHandlerFactory.GetHandlers(commandType);

            var actions = handlers
                .Select(h =>
                {
                    var trigger = cachedTriggers.GetOrAdd(h.GetType(), type =>
                    {
                        return CreateTrigger(type, commandType);
                    });
                    return new
                    {
                        Handler = h,
                        Trigger = trigger
                    };
                });
            foreach (var x in actions)
                x.Trigger(x.Handler, command);
        }

        private Action<ICommandHandler, ICommand> CreateTrigger(Type commandHandlerType, Type commandType)
        {
            Debug.WriteLine(string.Format("CreateTrigger : {0}", commandHandlerType.Name));
            Type cmdType = commandHandlerType
                .GetInterface(typeof(ICommandHandler<>).FullName)
                .GetGenericArguments()[0];
            DynamicMethod dynamicMethod = new DynamicMethod("TriggerMethod", null, new Type[] { typeof(ICommandHandler), typeof(ICommand) });
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, commandHandlerType);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Castclass, cmdType);
            il.Emit(OpCodes.Callvirt, commandHandlerType.GetMethod("Handle"));
            il.Emit(OpCodes.Ret);
            return (Action<ICommandHandler, ICommand>)dynamicMethod.CreateDelegate(typeof(Action<ICommandHandler, ICommand>));
        }

    }
}

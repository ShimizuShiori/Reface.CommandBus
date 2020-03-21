using System;

namespace Reface.CommandBus.Errors
{
    public class CommandHandlerNotFoundException : CommandBusException
    {
        public Type CommandType { get; private set; }

        public CommandHandlerNotFoundException(Type commandType)
        {
            CommandType = commandType;
        }
    }
}

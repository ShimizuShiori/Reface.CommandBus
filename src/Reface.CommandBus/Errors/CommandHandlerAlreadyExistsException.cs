using System;

namespace Reface.CommandBus.Errors
{
    public class CommandHandlerAlreadyExistsException : CommandBusException
    {
        public Type CommandType { get; private set; }

        public CommandHandlerAlreadyExistsException(Type type)
        {
            this.CommandType = type;
        }
    }
}

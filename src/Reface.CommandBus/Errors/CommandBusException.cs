using System;
using System.Runtime.Serialization;

namespace Reface.CommandBus.Errors
{
    public class CommandBusException : Exception
    {
        public CommandBusException()
        {
        }

        public CommandBusException(string message) : base(message)
        {
        }

        public CommandBusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommandBusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

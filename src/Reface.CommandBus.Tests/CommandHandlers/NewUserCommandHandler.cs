using Reface.CommandBus.Tests.Commands;
using System;

namespace Reface.CommandBus.Tests.CommandHandlers
{
    public class NewUserCommandHandler : ICommandHandler<NewUserCommand>
    {
        public object Handler(NewUserCommand command)
        {
            Console.WriteLine("Hello : {0}", command.UserName);
            return 1234;
        }
    }
}

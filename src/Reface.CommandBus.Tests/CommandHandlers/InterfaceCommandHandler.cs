using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests.CommandHandlers
{
    public class InterfaceCommandHandler : ICommandHandler<IInterfaceCommand>
    {
        public object Handler(IInterfaceCommand command)
        {
            command.Text = "Hello : " + command.Name;
            return null;
        }
    }
}

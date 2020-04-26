using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests.CommandHandlers
{
    public class HelloCommandHandler : ICommandHandler<HelloCommand>
    {
        public void Handle(HelloCommand command)
        {
            command.Text = string.Format("Hello {0}", command.Name);
        }
    }
}

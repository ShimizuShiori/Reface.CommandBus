using Reface.CommandBus.IntegrateAutofac.Tests.Commands;

namespace Reface.CommandBus.IntegrateAutofac.Tests.CommandHandlers
{
    public class ACommandHandler : ICommandHandler<ACommand>
    {
        public void Handle(ACommand command)
        {
            command.AResult = "A";
        }

        
    }
}

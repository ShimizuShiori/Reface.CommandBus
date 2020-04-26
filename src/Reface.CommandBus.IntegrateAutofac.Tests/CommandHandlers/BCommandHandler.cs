using Reface.CommandBus.IntegrateAutofac.Tests.Commands;

namespace Reface.CommandBus.IntegrateAutofac.Tests.CommandHandlers
{
    public class BCommandHandler : ICommandHandler<BCommand>
    {
        public void Handle(BCommand command)
        {
            command.BResult = "B";
        }

        
    }
}

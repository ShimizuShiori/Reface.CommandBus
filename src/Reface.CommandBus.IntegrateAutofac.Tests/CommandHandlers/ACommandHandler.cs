using Reface.CommandBus.IntegrateAutofac.Tests.Commands;

namespace Reface.CommandBus.IntegrateAutofac.Tests.CommandHandlers
{
    public class ACommandHandler : ICommandHandler<ACommand>
    {
        public object Handler(ACommand command)
        {
            return "A";
        }
    }
}

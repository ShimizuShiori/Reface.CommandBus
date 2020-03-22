using Reface.CommandBus.IntegrateAutofac.Tests.Commands;

namespace Reface.CommandBus.IntegrateAutofac.Tests.CommandHandlers
{
    public class BCommandHandler : ICommandHandler<BCommand>
    {
        public object Handler(BCommand command)
        {
            return "B";
        }
    }
}

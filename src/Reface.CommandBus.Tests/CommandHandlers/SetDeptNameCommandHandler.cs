using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests.CommandHandlers
{
    public class SetDeptNameCommandHandler : ICommandHandler<ISetDepNameCommand>
    {
        public void Handle(ISetDepNameCommand command)
        {
            command.DeptName = string.Format("DeptOf{0}", command.DeptId);
        }
    }
}

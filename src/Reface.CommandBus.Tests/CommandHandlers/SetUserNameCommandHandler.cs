using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests.CommandHandlers
{
    public class SetUserNameCommandHandler : ICommandHandler<ISetUserNameCommand>
    {
        public void Handle(ISetUserNameCommand command)
        {
            command.UserName = string.Format("UserOf{0}", command.UserId);
        }
    }
}

namespace Reface.CommandBus.Tests.Commands
{
    public class NewUserCommand : ICommand
    {
        public string UserName { get; private set; }

        public NewUserCommand(string userName)
        {
            UserName = userName;
        }
    }
}

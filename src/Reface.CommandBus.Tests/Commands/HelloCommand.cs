namespace Reface.CommandBus.Tests.Commands
{
    public class HelloCommand : ICommand
    {
        public string Name { get; private set; }

        public string Text { get; set; }

        public HelloCommand(string name)
        {
            this.Name = name;
        }
    }
}

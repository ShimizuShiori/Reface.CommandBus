namespace Reface.CommandBus
{
    public static class CommandBusExtensions
    {
        public static TResult Dispatch<TCommand, TResult>(this ICommandBus commandBus, TCommand command)
            where TCommand : ICommand
        {
            return (TResult)commandBus.Dispatch<TCommand>(command);
        }
    }
}

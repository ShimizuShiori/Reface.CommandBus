namespace Reface.CommandBus
{
    /// <summary>
    /// 命令处理器
    /// </summary>
    /// <typeparam name="TCommand">可以处理的命令</typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        object Handler(TCommand command);
    }
}

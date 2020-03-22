namespace Reface.CommandBus
{
    public interface ICommandHandler { }

    /// <summary>
    /// 命令处理器
    /// </summary>
    /// <typeparam name="TCommand">可以处理的命令</typeparam>
    public interface ICommandHandler<TCommand>:ICommandHandler
        where TCommand : ICommand
    {
        object Handler(TCommand command);
    }
}

namespace Reface.CommandBus
{
    /// <summary>
    /// 命令总线接口
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// 分配并执行命令
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        /// <exception cref="Reface.CommandBus.Errors.CommandHandlerNotFoundException">没有对应的处理器时的异常</exception>
        /// <returns></returns>
        object Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

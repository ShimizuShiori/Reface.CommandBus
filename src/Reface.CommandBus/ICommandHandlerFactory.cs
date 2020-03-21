namespace Reface.CommandBus
{
    /// <summary>
    /// 命令处理器工厂
    /// </summary>
    public interface ICommandHandlerFactory
    {
        /// <summary>
        /// 创建命令处理器
        /// </summary>
        /// <typeparam name="TCommand">命令的类型</typeparam>
        /// <exception cref="Reface.CommandBus.Errors.CommandHandlerNotFoundException">当命令不存在时的异常</exception>
        /// <returns></returns>
        ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand;
    }
}

using Reface.CommandBus.Core;

namespace Reface.CommandBus
{
    /// <summary>
    /// 命令处理器
    /// </summary>
    /// <typeparam name="TCommand">可以处理的命令</typeparam>
    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        /// <summary>
        /// 处理命令
        /// </summary>
        /// <param name="command"></param>
        void Handle(TCommand command);
    }
}

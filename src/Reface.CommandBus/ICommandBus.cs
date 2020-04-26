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
        /// <returns></returns>
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

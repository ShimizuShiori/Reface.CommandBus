namespace Reface.CommandBus.Core
{
    /// <summary>
    /// 命令处理器的内核类型。
    /// 开发者在开发命令处理器时，请不要从此接口实现，
    /// 请从 <see cref="ICommandHandler{TCommand}"/> 实现。
    /// </summary>
    public interface ICommandHandler
    {
    }
}

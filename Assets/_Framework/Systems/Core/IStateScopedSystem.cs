
using GameVault.FrameWork.Lifecyle;

namespace GameVault.FrameWork.System
{
    /// <summary>
    /// Maker Interface for systems that are active only
    /// in a specific gamestate
    /// </summary>
    public interface IStateScopedSystem : ISystem
    {
        GameState State { get; }
        bool IsActive { get; set; }
    }
}

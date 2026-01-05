

using GameVault.FrameWork.Lifecyle;

namespace GameVault.FrameWork.System
{
    public interface IStateScopedUISystem : ISystem
    {
        GameState State { get; }
        void Show();
        void Hide();

    }
}
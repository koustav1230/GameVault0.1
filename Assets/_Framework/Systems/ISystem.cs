
namespace GameVault.FrameWork.System
{
    /// <summary>
    /// Defines what every system must support, nothing more.
    /// </summary>
    public interface ISystem
    {
        void Initialize();
        void Tick(float deltaTime);
        void Dispose();
    }
}
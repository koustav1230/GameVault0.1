
namespace GameVault.FrameWork.System
{
    /// <summary>
    /// Avoid empty method implementations
    /// Give systems access to GameContext safely
    /// </summary>
    public abstract class SystemBase : ISystem
    {
        protected GameContext context => GameContext.Instance;

        public virtual void Dispose(){}

        public virtual void Initialize(){}

        public virtual void Tick(float deltaTime){}

    }
}

using System.Collections;

namespace GameVault.FrameWork.System.Loading
{
    public interface ILoadingPhase
    {
        string Name { get; }

        /// <summary>
        /// Blocking or nonblocking
        /// </summary>
        LoadingPhaseType Type { get; }

        /// <summary>
        /// Relative contribution to total loading progress (0 -> 1 range, normalized later)
        /// </summary>
        float Weight {  get; }

        /// <summary>
        /// Called once when load state begings
        /// </summary>
        void Begin();

        /// <summary>
        /// called every frame while phase is active
        /// </summary>
        /// <param name="deltaTime"></param>
        void Tick(float deltaTime);



        /// <summary>
        /// 0 -> 1 progress for this phase only
        /// </summary>
        float Progress { get; }
        
        /// <summary>
        ///True when phase work is finished
        /// </summary>
        bool IsCompleted {  get; }

        /// <summary>
        /// calls once when phase is removed or loading ends
        /// </summary>
        void Dispose();
    }
}


using UnityEngine;

namespace GameVault.FrameWork.System
{
    /// <summary>
    /// The ONLY MonoBehaviour that ticks systems
    /// Converts Unity Update  Engine Tick
    /// </summary>
    public sealed class SystemRunner : MonoBehaviour
    {

        public void Update()
        {
            if(!GameContext.IsCreated)
            {
                return;
            }
            GameContext.Instance.System.TickAll(Time.deltaTime);
        }
    }
}

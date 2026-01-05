
using GameVault.FrameWork.Core.GameFlow;
using UnityEngine;

namespace GameVault.FrameWork.System.Input
{
    public class DebugInputSystem : SystemBase
    {
        private GameFlowSystem _flow;

        public override void Initialize()
        {
            _flow = context.System.Get<GameFlowSystem>();
        }

        public override void Tick(float deltaTime)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.M))
            {
                _flow.RequestMainMenu();
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.G))
            {
                _flow.RequestGamePlay();
            }

        }
    }
}

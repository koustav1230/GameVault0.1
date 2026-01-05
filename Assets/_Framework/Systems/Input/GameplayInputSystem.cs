
using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using UnityEngine;

namespace GameVault.FrameWork.System
{
    public sealed class GameplayInputSystem : SystemBase,IStateScopedSystem
    {
        public GameState State => GameState.GamePlay;

        public bool IsActive { get; set; }

        public override void Initialize()
        {
            IsActive = false;
            UnityEngine.Debug.Log("[GameplaySystem] Initialized");
        }

        public override void Tick(float deltaTime)
        {
            if(!IsActive)
            {
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.M))
            {
                context.System.Get<GameFlowSystem>().RequestMainMenu();
            }

        }

        public override void Dispose()
        {
            UnityEngine.Debug.Log("[GameplaySystem] disposed");
        }
    }
}

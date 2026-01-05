

using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using UnityEngine;

namespace GameVault.FrameWork.System
{
    public sealed class MainMenuInputSystem : SystemBase,IStateScopedSystem
    {
        public GameState State => GameState.MainMenu;

        public bool IsActive { get; set; }

        public override void Initialize()
        {
            IsActive = false;
            UnityEngine.Debug.Log("[MianMenuSystem] Initialized");
        }

        public override void Tick(float deltaTime)
        {
            if(!IsActive)
            {
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.G))
            {
                context.System.Get<GameFlowSystem>().RequestGamePlay();
            }

        }

        public override void Dispose()
        {
            UnityEngine.Debug.Log("[MainMenuSystem] Disposed");
        }
    }
}
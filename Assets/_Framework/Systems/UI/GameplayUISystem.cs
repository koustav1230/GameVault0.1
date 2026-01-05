
using GameVault.FrameWork.Lifecyle;
using UnityEngine;

namespace GameVault.FrameWork.System
{
    public sealed class GameplayUISystem : SystemBase, IStateScopedUISystem
    {
        public GameState State => GameState.GamePlay;

        private bool _visible;
        public override void Initialize()
        {
            _visible = false;
            Debug.Log("[GameplayUI] Initialized");
        }
        public void Show()
        {
            if (_visible) 
            {
                return;
            }
            _visible = true;
            Debug.Log("[GameplayUI] Show");
        }
        public void Hide()
        {

            if (!_visible)
            {
                return;
            }
            _visible = false;
            Debug.Log("[GameplayUI] Hide");
        }

    
    }
}

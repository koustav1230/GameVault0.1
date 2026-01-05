
using GameVault.FrameWork.Lifecyle;
using UnityEngine;

namespace GameVault.FrameWork.System
{
    public sealed class MainMenuUISystem : SystemBase, IStateScopedUISystem
    {
        public GameState State => GameState.MainMenu;
        private bool _visible;

        public override void Initialize()
        {
            _visible = false;
            Debug.Log("[MianMenuUI] Initialized");
        }

        public void Show()
        {
            if (_visible)
            {
                return;
            }
            _visible = true;
            Debug.Log("[MianMenuUI] Show");
        }
        public void Hide()
        {
            if (!_visible)
            {
                return;
            }
            _visible = false;
            Debug.Log("[MainMenuUI] Hide");
        }

   
    }
}
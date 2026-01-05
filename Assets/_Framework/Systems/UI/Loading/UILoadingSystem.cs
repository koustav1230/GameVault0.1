using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.SceneManagement;
using GameVault.FrameWork.System;
using UnityEngine;

namespace GameVault.FrameWork.Presentation.Loading
{
    public sealed class UILoadingSystem : SystemBase ,IStateScopedUISystem
    {

        public GameState State => GameState.Loading;

        private ILoadingProgressProvider _progressProvider;
        private bool _visible;


        public override void Initialize()
        {
            _progressProvider = context.System.Get<SceneSystem>();
            _visible = false;

            Debug.Log("[UILoading] Initialized");

        }



        public override void Tick(float deltaTime)
        {
            if (!_visible || !_progressProvider.IsLoading)
            {
                return;
            }

            UpdateProgress(_progressProvider.Progress);
        }


        public void Show()
        {
            if (_visible)
            {
                return;
            }
            _visible = true;

            Debug.Log("[UILoading] Show");
            UpdateProgress(0f);

        }

        public void Hide()
        {
            if(!_visible)
            {
                return ;
            }  
            _visible = false;
            Debug.Log("[UILoading] Hide");
        }

        private void UpdateProgress(float value)
        {
            Debug.Log($"[UILoading] Progress: {(int)(value * 100)}%");
        }
    }
}
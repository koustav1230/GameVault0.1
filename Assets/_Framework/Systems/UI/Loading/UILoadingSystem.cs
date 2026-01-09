using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.SceneManagement;
using GameVault.FrameWork.System;
using GameVault.FrameWork.System.Loading;
using UnityEngine;

namespace GameVault.FrameWork.Presentation.Loading
{
    public sealed class UILoadingSystem : SystemBase ,IStateScopedUISystem
    {

        private LoadingOrchestratorSystem _orchestrator;
        private ILoadingProgressProvider _progressProvider;
        private bool _visible;

        public GameState State => GameState.Loading;

        public override void Initialize()
        {
            _progressProvider = context.System.Get<SceneSystem>();
            _orchestrator = context.System.Get<LoadingOrchestratorSystem>();
            _visible = false;

            Debug.Log("[UILoading] Initialized");

        }



        public override void Tick(float deltaTime)
        {
            if (!_visible)
            {
                return;
            }

            UpdateProgress(_orchestrator.Progress);
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
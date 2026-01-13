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

        private LoadingProgressSmoother _smoother;
        public GameState State => GameState.Loading;

        public override void Initialize()
        {
            _progressProvider = context.System.Get<SceneSystem>();
            _orchestrator = context.System.Get<LoadingOrchestratorSystem>();
            _smoother = new LoadingProgressSmoother();
            _visible = false;

            Debug.Log("[UILoading] Initialized");

        }



        public override void Tick(float deltaTime)
        {
            if (!_visible)
            {
                return;
            }

            float rawProgress = _orchestrator.Progress;
            float smoothed = _smoother.Tick(rawProgress, deltaTime);

            UpdateProgress(smoothed);
        }


        public void Show()
        {
            if (_visible)
            {
                return;
            }
            _visible = true;
            _smoother.Reset();

            Debug.Log("[UILoading] Show");
            UpdateProgress(0f);

        }

        public void Hide()
        {
            if(!_visible)
            {
                return;
            } 

            _smoother.MarkCompleted();
            UpdateProgress(1f);
            _visible = false;
            Debug.Log("[UILoading] Hide");
        }

        private void UpdateProgress(float value)
        {
            Debug.Log($"[UILoading] Progress: {(int)(value * 100)}%");
        }
    }
}

using UnityEngine;

namespace GameVault.FrameWork.System.Loading.Phases
{
    public sealed class WarmupCachePhase : ILoadingPhase
    {

        private float _progress;
        public string Name => "Warmup Cache";

        public LoadingPhaseType Type => LoadingPhaseType.NonBlocking;

        //very small inpact on ui
        public float Weight => 0.1f;

        public float Progress => _progress;

        public bool IsCompleted => _progress >= 1f;

        public void Begin()
        {
            _progress = 0f;
            Debug.Log("[WarmupCachePhase] Started");
        }
        public void Tick(float deltaTime)
        {

            //Simulate Background Work

            _progress += deltaTime * 0.25f;
            _progress = Mathf.Clamp01(_progress);

            if(IsCompleted)
            {
                Debug.Log("[WarmupCachePhase] Completed");
            }
        }

        public void Dispose()
        {
            Debug.Log("[WarmupCachePhase] Disposed");
        }

    }
}

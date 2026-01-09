
using UnityEngine;

namespace GameVault.FrameWork.System.Loading.Phases
{
    public sealed class MinimumTimePhase : ILoadingPhase
    {
        private readonly float _duration;
        private float _elapsed;

        public string Name => "Minimum Load Time";

        public LoadingPhaseType Type => LoadingPhaseType.Blocking;

        public float Weight => 0.2f;

        public float Progress => Mathf.Clamp01(_elapsed / _duration);

        public bool IsCompleted => _elapsed >= _duration;


        public MinimumTimePhase(float durationSecond)
        {
            _duration = durationSecond;
        }



        public void Begin()
        {
            _elapsed = 0f;
        }


        public void Tick(float deltaTime)
        {
            _elapsed += deltaTime;
        }
        public void Dispose()
        {
          
        }
    }
}

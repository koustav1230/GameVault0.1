using UnityEngine;

namespace GameVault.FrameWork.Presentation.Loading
{
    public sealed class LoadingProgressSmoother
    {
        private float _displayed;
        private bool _completed;

        //Tunable but safe defaults

        private const float SmoothSpeed = 6f;
        private const float MaxBeforeComplete = 0.99f;

        public void Reset()
        {
            _displayed = 0f;
            _completed = false;
        }

        public void MarkCompleted()
        {
            _completed = true;
        }

        public float Tick(float rawProgress, float deltaTime)
        {
            //never go backward.
            rawProgress = Mathf.Max(rawProgress, _displayed);

            if(!_completed)
            {
                rawProgress = Mathf.Min(rawProgress, MaxBeforeComplete);
            }

            _displayed = Mathf.MoveTowards(_displayed, rawProgress, SmoothSpeed * deltaTime);

            return _displayed;

        }
    }
}
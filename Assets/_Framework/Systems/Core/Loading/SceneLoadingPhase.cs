using GameVault.FrameWork.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameVault.FrameWork.System.Loading
{
    public sealed class SceneLoadingPhase : ILoadingPhase
    {

        private readonly SceneSystem _sceneSystem;
        private readonly SceneID _target;

        private bool _started;
        public string Name => "Scene Loading";

        public LoadingPhaseType Type => LoadingPhaseType.Blocking;

        public float Weight => 0.6f;

        public float Progress => _sceneSystem.IsLoading ? _sceneSystem.Progress : (_started ? 1f : 0f);
        public bool IsCompleted => _started && !_sceneSystem.IsLoading;

        public SceneLoadingPhase(SceneSystem sceneSystem, SceneID target)
        {
            _sceneSystem = sceneSystem;
            _target = target;
        }


        public void Begin()
        {
            if(_started)
            {
                return;
            }
            _started = true;
            _sceneSystem.Load(_target);
        }

        public void Tick(float deltaTime)
        {
            // SceneSystem already updates progress internally
            // Nothing to do here for now
        }

        public void Dispose()
        {
            _started = false;
        }

        // OPTIONAL: keep for compatibility/testing only
        public IEnumerator Execute()
        {
            _sceneSystem.Load(_target);

            if (_sceneSystem.IsLoading)
            {
                yield return null;
            }
        }
    }
}

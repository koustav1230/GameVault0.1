using GameVault.FrameWork.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameVault.FrameWork.System.Loading.Phases
{
    public sealed class SceneLoadingPhase : ILoadingPhase
    {

        private readonly SceneSystem _sceneSystem;
        private readonly SceneID _targetScene;

        public string Name => "Scene Loading";

        public LoadingPhaseType Type => LoadingPhaseType.Blocking;

        public float Weight => 0.6f;

        public float Progress => _sceneSystem.Progress;
        public bool IsCompleted => !_sceneSystem.IsLoading;

        public SceneLoadingPhase(SceneSystem sceneSystem, SceneID target)
        {
            _sceneSystem = sceneSystem;
            _targetScene = target;
        }


        public void Begin()
        {
           _sceneSystem.Load(_targetScene);
        }

        public void Tick(float deltaTime)
        {
            // SceneSystem already updates progress internally
            // Nothing to do here for now
        }

        // OPTIONAL: keep for compatibility/testing only
        public IEnumerator Execute()
        {
            Begin();

            if (_sceneSystem.IsLoading)
            {
                yield return null;
            }
        }
        public void Dispose()
        {
            
        }

    }
}

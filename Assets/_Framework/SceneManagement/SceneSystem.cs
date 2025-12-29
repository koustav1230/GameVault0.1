using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

namespace GameVault.FrameWork.SceneManagement
{
    public sealed class SceneSystem : SystemBase
    {
        private SceneConfig _config;
        public override void Initialize()
        {
          _config = new SceneConfig();
           context.Lifecycle.OnStateChanged += OnSceneChange;
        }

        public override void Dispose()
        {
            context.Lifecycle.OnStateChanged -= OnSceneChange;
        }

        private void OnSceneChange(GameState from,GameState to)
        {
            if(!_config.TryGetScene(to, out var sceneID))
            {
                return;
            }

            var sceneName = _config.GetSceneName(sceneID);

            if(SceneManager.GetActiveScene().name.Equals(sceneName))
            {
                return;
            }

            UnityEngine.Debug.Log($"[SceneSystem] Loading Scene : {sceneName}");
            SceneManager.LoadScene(sceneName);

        }
    }
}

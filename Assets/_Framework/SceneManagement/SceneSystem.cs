using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.System;
using System.Collections;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameVault.FrameWork.SceneManagement
{
    public sealed class SceneSystem : SystemBase, ILoadingProgressProvider
    {
        private SceneConfig _config;
        private Coroutine _loadingRouting;
        private ISceneLoadListener _loadListener;


        private float _progress;
        private bool _isLoading;

        public float Progress => _progress;
        public bool IsLoading => _isLoading;

        public override void Initialize()
        {
          _config = new SceneConfig();
        }

        public void RegisterLoadListener(ISceneLoadListener listener)
        {
            _loadListener = listener;
        }


        public void Load(SceneID sceneID)
        {
            if (_isLoading)
                return;

            _loadingRouting = context.SystemRunner.Run(LoadRoutine(sceneID));
        }


        private IEnumerator LoadRoutine(SceneID targetScene)
        {
            _isLoading = true;
            _progress = 0f;

            //phase 1 - Load Loading scene

            yield return LoadUnityScene(SceneID.Loading);

            //Phase 2 - Load target scene

            yield return LoadUnityScene(targetScene);

            _isLoading = false;
            _loadListener?.OnSceneLoadCompleted();
        }

        private IEnumerator LoadUnityScene(SceneID sceneID)
        {

            var sceneName = _config.GetSceneName(sceneID);
            //UnityEngine.Debug.Log($"[SceneSystem] Loading Scene : {sceneName}");

            var op = SceneManager.LoadSceneAsync(sceneName);
            op.allowSceneActivation = false;

            while (op.progress < 0.9f)
            {
                _progress = op.progress / 0.9f; // normalized 0 - 1
                yield return null;
            }


            _progress = 1f;
            op.allowSceneActivation = true;
            yield return null;

        }


    }
}

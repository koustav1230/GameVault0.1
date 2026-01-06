using GameVault.FrameWork.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameVault.FrameWork.System.Loading
{
    public sealed class LoadingOrchestratorSystem : SystemBase, ILoadingProgressProvider
    {
        private LoadingPipeline _pipeline;
        private float _progress;
        private bool _isloading;

        public float Progress => _progress;

        public bool IsLoading => _isloading;

        public override void Initialize()
        {
            Debug.Log("[LoadingOrchestratorSystem] Initialized");
        }

        public void StartLoading(SceneID targetScene)
        {
            if(_isloading)
            {
                return;
            }

            _pipeline = new LoadingPipeline();

            _pipeline.AddPhase(new SceneLoadingPhase(context.System.Get<SceneSystem>(),targetScene));
            _isloading = true;
            //context.SystemRunner.Run(RunPipeline());
        }

        //private IEnumerator RunPipeline()
        //{
        //    var runner = _pipeline.Run();

        //    while(runner.MoveNext())
        //    {
        //        _progress = _pipeline.TotalProgress;
        //        yield return null;

        //    }
        //    _progress = 0f;
        //    _isloading = false;
        //}

    }
}

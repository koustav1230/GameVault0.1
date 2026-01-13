using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.System.Loading.Phases;
using GameVault.FrameWork.SceneManagement;
using UnityEngine;

namespace GameVault.FrameWork.System.Loading
{
    public sealed class LoadingOrchestratorSystem : SystemBase
    {
        private LoadingPipeline _pipeline;
        private GameState _targetState;


        public float Progress => _pipeline?.Progress ?? 0f;
        public override void Initialize()
        {
            Debug.Log("[LoadingOrchestratorSystem] Initialized");
        }


        public override void Tick(float deltaTime)
        {
            if(_pipeline == null)
            {
                return;
            }

            _pipeline.Tick(deltaTime);
            if(_pipeline.State == Pipeline.LoadingPipelineState.AwaitingCompletion)
            {
                OnPipelineCompleted();
            }
        }

        /// <summary>
        /// public api (called by Gameflow)
        /// </summary>
        /// <param name="targetState"></param>
        public void BeginLoading(GameState targetState)
        {
            _targetState = targetState;
            BuildPipeline(targetState);
            _pipeline.Start();
        }

        /// <summary>
        /// pipeline setup
        /// </summary>
        /// <param name="targetState"></param>
        private void BuildPipeline(GameState targetState)
        {

            _pipeline = new LoadingPipeline();

            var sceneSystem = context.System.Get<SceneSystem>();
            SceneID targetScene = targetState == GameState.MainMenu ? SceneID.MainMenu : SceneID.GamePlay;

            //blocking Phase
            _pipeline.AddPhase(new SceneLoadingPhase(sceneSystem, targetScene));
            _pipeline.AddPhase(new MinimumTimePhase(1.5f));

            //Non-Blocking Phase
            _pipeline.AddPhase(new WarmupCachePhase());

            Debug.Log($"[LoadingOrchestratorSystem] pipeline built for {targetState}");
        }

        private void OnPipelineCompleted()
        {
            Debug.Log("[LoadingOrchestratorSystem] Pipeline completed");

            _pipeline.Complete();
            _pipeline = null;

            context.System.Get<GameFlowSystem>().OnLoadingCompleted(_targetState);

        }


    }
}

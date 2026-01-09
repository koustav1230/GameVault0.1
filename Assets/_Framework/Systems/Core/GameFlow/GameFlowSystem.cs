
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.SceneManagement;
using GameVault.FrameWork.System;
using GameVault.FrameWork.System.Loading;


namespace GameVault.FrameWork.Core.GameFlow
{
    public class GameFlowSystem : SystemBase
    {

        private GameState _pendingTarget;
        private bool _isLoading;

     
        public override void Initialize()
        {
         
        }

        public void RequestMainMenu()=>
            Begin(GameState.MainMenu);

        public void RequestGamePlay()=>
            Begin(GameState.GamePlay);
        
        public void RequestQuit()=>
           context.Lifecycle.ChangeState(GameState.ShutDown);

        private void Begin(GameState target)
        {
           
            if(context.Lifecycle.CurrentState == target)
            {
                return;
            }

            if (_isLoading)
            {
                return;
            }

            _isLoading = true;
            _pendingTarget = target;

            context.Lifecycle.ChangeState(GameState.Loading);

            context.System.Get<LoadingOrchestratorSystem>().BeginLoading(target);

         
        }

        public void OnLoadingCompleted(GameState targetState)
        {
         
            _isLoading = false;
            context.Lifecycle.ChangeState(targetState);
        }
    }

}


using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.SceneManagement;
using GameVault.FrameWork.System;


namespace GameVault.FrameWork.Core.GameFlow
{
    public class GameFlowSystem : SystemBase, ISceneLoadListener
    {
        private SceneSystem _sceneSystem;
        private GameState _targetState;
        private bool _isLoading;

     
        public override void Initialize()
        {
            _sceneSystem = context.System.Get<SceneSystem>();
            _sceneSystem.RegisterLoadListener(this);
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
            _targetState = target;

            context.Lifecycle.ChangeState(GameState.Loading);

            _sceneSystem.Load(target == GameState.MainMenu ? SceneID.MainMenu : SceneID.GamePlay);

         
        }

        public void OnSceneLoadCompleted()
        {
            if (!_isLoading)
                return;

            _isLoading = false;
            context.Lifecycle.ChangeState(_targetState);
        }
    }

}

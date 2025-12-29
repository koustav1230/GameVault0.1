
using GameVault.FrameWork.Lifecyle;
using System;

namespace GameVault.FrameWork
{
    public sealed class LifecycleController
    {
        public GameState CurrentState { get; private set; } = GameState.none;
        public event Action<GameState,GameState> OnStateChanged;

        internal void Initilize()
        {
            ChangeState(GameState.Boot);
        }

        public void ChangeState(GameState newState)
        {
            if(newState == CurrentState)
            {
                return;
            }
            if(!IsTrasitionValid(CurrentState,newState))
            {
                throw new InvalidCastException($"Invalid State Transition -> {newState}");
            }

            var previousState = CurrentState;
            CurrentState = newState;
            OnStateChanged?.Invoke(previousState, newState);

        }

        private bool IsTrasitionValid(GameState from,GameState to)
        {
            switch(from)
            {
                case GameState.none:
                    return to == GameState.Boot;
                case GameState.Boot:
                    return to == GameState.Loading || to == GameState.MainMenu;
                case GameState.Loading:
                    return to == GameState.MainMenu || to == GameState.GamePlay;
                case GameState.MainMenu:
                    return to == GameState.GamePlay || to == GameState.ShutDown;
                case GameState.GamePlay:
                    return to == GameState.Paused || to == GameState.Result;
                case GameState.Paused:
                    return to == GameState.GamePlay || to == GameState.MainMenu;
                case GameState.Result:
                    return to == GameState.MainMenu || to == GameState.ShutDown;
                default:
                    return false;

            }
        }
    }
}

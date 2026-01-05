using System;
using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.Presentation.Loading;
using GameVault.FrameWork.SceneManagement;
using GameVault.FrameWork.System;
using GameVault.FrameWork.System.Input;

namespace GameVault.FrameWork
{
    public sealed class GameContext
    {
        private static GameContext _instance;
        private LifecycleController _lifecycle;
        private SystemRegistry _system;
        private SystemRunner _systemRunner;


        public static GameContext Instance => _instance;

        public static bool IsCreated => _instance != null;
        public LifecycleController Lifecycle => _lifecycle;
        public SystemRegistry System => _system;

        public SystemRunner SystemRunner => _systemRunner;

        /// <summary>
        /// All Initilize should explitly happens here
        /// </summary>
        private GameContext()
        {
            // Constructor intentionally minimal
            // All initialization happens explicitly
        }


        public static void Create(SystemRunner runner,Action<GameState,GameState> listener)
        {

           if(_instance != null)
            {
                throw new InvalidOperationException("GameContext Has Already Been Created");
            }

           if(runner == null)
            {
                throw new ArgumentException(nameof(runner));

            }
           _instance = new GameContext();
            _instance._systemRunner = runner;
           _instance._lifecycle = new LifecycleController();
           _instance.Lifecycle.OnStateChanged += listener;
           _instance.Initilize();

        }

        public static void Destroy()
        {
            if(_instance == null)
            {
                return;
            }
            _instance.Dispose();
            _instance = null;
        }

        private void Initilize()
        {
            // Future:
            // - Create lifecycle controller
            // - Create system registry
            // - Initialize core services

            _system = new SystemRegistry();
            _system.Register(new DebugLifecycleSystem());
            _system.Register(new GameFlowSystem());
            _system.Register(new StateScopeSystem()); 
            _system.Register(new SceneSystem());
            _system.Register(new UILoadingSystem());
            _system.Register(new MainMenuInputSystem());
            _system.Register(new GameplayInputSystem());
            _system.Register(new MainMenuUISystem());
            _system.Register(new GameplayUISystem());

            _system.InitializeAll();


            _lifecycle.Initilize();
          

        }


        private void Dispose()
        {
            // Future:
            // - Shutdown systems
            // - Dispose services

            _system.DisposeAll();
            _system = null;
            _lifecycle = null;
        }
    }
}
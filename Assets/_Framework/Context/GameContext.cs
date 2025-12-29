using System;
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.SceneManagement;
using GameVault.FrameWork.System;

namespace GameVault.FrameWork
{
    public sealed class GameContext
    {
        private static GameContext _instance;
        private LifecycleController _lifecycle;
        private SystemRegistry _system;

        public static GameContext Instance => _instance;

        public static bool IsCreated => _instance != null;
        public LifecycleController Lifecycle => _lifecycle;
        public SystemRegistry System => _system;

        /// <summary>
        /// All Initilize should explitly happens here
        /// </summary>
        private GameContext()
        {
            // Constructor intentionally minimal
            // All initialization happens explicitly
        }


        public static void Create(Action<GameState,GameState> listener)
        {
           if(_instance != null)
            {
                throw new InvalidOperationException("GameContext Has Already Been Created");
            }
           _instance = new GameContext();
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
            _system.Register(new SceneSystem());

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
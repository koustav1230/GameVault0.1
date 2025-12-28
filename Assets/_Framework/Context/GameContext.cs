using System;
using GameVault.FrameWork.Lifecyle;

namespace GameVault.FrameWork
{
    public sealed class GameContext
    {
        private static GameContext _instance;
        private LifecycleController _lifecycle;


        public static GameContext Instance => _instance;

        public static bool IsCreated => _instance != null;
        public LifecycleController Lifecycle => _lifecycle;

        /// <summary>
        /// All Initilize should explitly happens here
        /// </summary>
        private GameContext()
        {
            // Constructor intentionally minimal
            // All initialization happens explicitly
        }


        public static void Create()
        {
           if(_instance != null)
            {
                throw new InvalidOperationException("GameContext Has Already Been Created");
            }
           _instance = new GameContext();
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

            _lifecycle = new LifecycleController();
            _lifecycle.Initilize();


        }


        private void Dispose()
        {
            // Future:
            // - Shutdown systems
            // - Dispose services

            _lifecycle = null;
        }
    }
}
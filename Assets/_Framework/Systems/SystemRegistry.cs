
using System;
using System.Collections.Generic;

namespace GameVault.FrameWork.System
{
    /// <summary>
    /// Own all systems
    /// Control order
    /// Initialize / Tick / Dispose them
    /// </summary>
    public sealed class SystemRegistry 
    {
        private List<ISystem> _systems = new List<ISystem>();
        private bool _initialized;

        public void Register(ISystem system)
        {
            if (_initialized)
            {
                throw new InvalidCastException("Cannot Register System After Initialization");
            }
            if (system == null)
            {
                throw new ArgumentNullException($"{nameof(system)}");
            }
            _systems.Add(system);
        }

        public void InitializeAll()
        {
            if (_initialized)
            {
                return;
            }
            _initialized = true;
            foreach (ISystem system in _systems)
            {
                system.Initialize();
            }
        }

        public void TickAll(float deltaTime)
        {
            if (!_initialized)
            {
                return;
            }
            foreach (ISystem system in _systems)
            {
                system.Tick(deltaTime);
            }
        }


        public void DisposeAll()
        {
            for (int i = _systems.Count - 1; i >= 0; i--)
            {
                _systems[i].Dispose();
            }
            _systems.Clear();
            _initialized = false;
        }

    }
}
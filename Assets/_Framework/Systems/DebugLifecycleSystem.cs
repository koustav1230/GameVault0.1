using GameVault.FrameWork.Lifecyle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameVault.FrameWork.System
{
    public class DebugLifecycleSystem : SystemBase
    {
        private float _timer = 0f;

        public override void Initialize()
        {

            context.Lifecycle.OnStateChanged += OnStateChange;
            Debug.Log("[DebugLifecycleSystem] Initialized");
        }

        public override void Tick(float deltaTime)
        {
           _timer += deltaTime;
            if (_timer >= 1f )
            {
                _timer = 0f;
                Debug.Log("DebugLifecycle Ticked....");

            }
        }

        public override void Dispose()
        {
           if(context.Lifecycle != null)
            {
                context.Lifecycle.OnStateChanged -= OnStateChange;
            }
            Debug.Log("[DebugLifecycleSystem Disposed]");
        }


        private void OnStateChange(GameState from, GameState to)
        {
            Debug.Log($"{from} -> {to}");
        }

    }
}

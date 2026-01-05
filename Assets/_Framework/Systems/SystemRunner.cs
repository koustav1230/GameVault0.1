
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameVault.FrameWork.System
{
    /// <summary>
    /// The ONLY MonoBehaviour that ticks systems
    /// Converts Unity Update  Engine Tick
    /// </summary>
    public sealed class SystemRunner : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        public void Update()
        {
            if(!GameContext.IsCreated)
            {
                return;
            }
            GameContext.Instance.System.TickAll(Time.deltaTime);
        }

        public Coroutine Run(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }
}

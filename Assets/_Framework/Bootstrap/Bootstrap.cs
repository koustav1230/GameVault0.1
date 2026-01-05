
using GameVault.FrameWork.Core.GameFlow;
using GameVault.FrameWork.Lifecyle;
using GameVault.FrameWork.System;
using UnityEngine;

namespace GameVault.FrameWork.Bootstrap
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SystemRunner systemRunner;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(systemRunner.gameObject);

            if (!GameContext.IsCreated)
            {
                GameContext.Create(systemRunner, OnStateChanged);
                GameContext.Instance.System.Get<GameFlowSystem>().RequestMainMenu();
            
            }
            else
            {
                Destroy(gameObject);
            }

        }


        private void Update()
        {
        }

        void OnStateChanged(GameState c , GameState x)
        {
            //UnityEngine.Debug.Log($"{c} -> {x}");
        }
  
    }

}
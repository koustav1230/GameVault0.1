
using UnityEngine;
using GameVault.FrameWork;
using System.Diagnostics;
using GameVault.FrameWork.Lifecyle;

namespace GameVault.FrameWork.Bootstrap
{
    public sealed class Bootstrap : MonoBehaviour
    {

        private void Awake()
        {

            DontDestroyOnLoad(gameObject);
            GameContext.Create();

            GameContext.Instance.Lifecycle.OnStateChanged += Test;


        }

  
        void Test(GameState c , GameState x)
        {
            UnityEngine.Debug.Log($"{c} -> {x}");
        }
        private void OnDestroy()
        {
            GameContext.Instance.Lifecycle.OnStateChanged -= Test;
            GameContext.Destroy();
        }
    }

}
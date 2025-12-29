
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
            GameContext.Create(Test);

        }


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                GameContext.Instance.Lifecycle.ChangeState(GameState.MainMenu);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                GameContext.Instance.Lifecycle.ChangeState(GameState.GamePlay);
            }

        }

        void Test(GameState c , GameState x)
        {
            //UnityEngine.Debug.Log($"{c} -> {x}");
        }
        private void OnDestroy()
        {
            GameContext.Instance.Lifecycle.OnStateChanged -= Test;
            GameContext.Destroy();
        }
    }

}
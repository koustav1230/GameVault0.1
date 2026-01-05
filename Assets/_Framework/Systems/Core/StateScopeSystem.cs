
using GameVault.FrameWork.Lifecyle;
using System;
using System.Collections.Generic;

namespace GameVault.FrameWork.System
{
    public sealed class StateScopeSystem : SystemBase
    {
        public override void Initialize()
        {
            context.Lifecycle.OnStateChanged += OnStateChanged;
        }

        public override void Dispose()
        {
            context.Lifecycle.OnStateChanged -= OnStateChanged;
        }

        private void OnStateChanged(GameState from, GameState to)
        {


            if (to == GameState.none || to == GameState.Boot)
            {
                return;
            }
            foreach (var system in context.System.GetAll<IStateScopedSystem>())
            {
                system.IsActive = system.State == to;
            }

            foreach(var Ui in context.System.GetAll<IStateScopedUISystem>())
            {
                if(Ui.State == to)
                {
                    Ui.Show();
                }
                else
                {
                    Ui.Hide();
                }
            }
        }


    }
}

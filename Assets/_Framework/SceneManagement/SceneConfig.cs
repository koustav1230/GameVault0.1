using GameVault.FrameWork.Lifecyle;
using System.Collections.Generic;

namespace GameVault.FrameWork.SceneManagement
{
    /// <summary>
    /// Decouples : GameState ,SceneId,Actual Unity scene names
    /// </summary>
    public sealed class SceneConfig
    {
        private readonly Dictionary<GameState, SceneID> _stateToScene = new Dictionary<GameState, SceneID>
        {
            {GameState.Boot, SceneID.Bootstrap},
            {GameState.MainMenu, SceneID.MainMenu},
            {GameState.GamePlay, SceneID.GamePlay}
        };

        private readonly Dictionary<SceneID, string> _sceneNames = new Dictionary<SceneID, string>
        {
            {SceneID.Bootstrap,"Bootstrap" },
            {SceneID.MainMenu,"MainMenu" },
            {SceneID.GamePlay,"GamePlay" },

        };

        public bool TryGetScene(GameState state,out SceneID sceneID)
        {
            return _stateToScene.TryGetValue(state,out sceneID);
        }

        public string GetSceneName(SceneID sceneID)
        {
            return _sceneNames[sceneID];
        }
    }
}
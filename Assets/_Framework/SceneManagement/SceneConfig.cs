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
            { GameState.Loading , SceneID.Loading},
            {GameState.MainMenu, SceneID.MainMenu},
            {GameState.GamePlay, SceneID.GamePlay}

        };

        private readonly Dictionary<SceneID, string> _sceneNames = new Dictionary<SceneID, string>
        {
            {SceneID.Loading,"Loading" },
            {SceneID.MainMenu,"MainMenu" },
            {SceneID.GamePlay,"GamePlay" }
        
        };

        public bool TryGetScene(GameState state,out SceneID sceneID) =>_stateToScene.TryGetValue(state,out sceneID);
        

        public string GetSceneName(SceneID sceneID) => _sceneNames[sceneID];
        

        //for later use
        public bool IsLoadingScene(SceneID id) => id == SceneID.Loading;
        

    }
}
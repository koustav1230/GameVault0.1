
namespace GameVault.FrameWork.SceneManagement
{
    /// <summary>
    /// Allows remapping without touching systems
    /// Each game can extend this enum safely.
    /// </summary>
    public enum SceneID
    {
        none = 0,


        Bootstrap,
        MainMenu,
        GamePlay,
        Loading
    }
}
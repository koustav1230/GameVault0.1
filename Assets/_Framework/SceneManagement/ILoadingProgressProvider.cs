using UnityEngine;

namespace GameVault.FrameWork.SceneManagement
{
    public interface ILoadingProgressProvider
    {
        float Progress { get; }
        bool IsLoading { get; }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameVault.FrameWork.System.Loading
{
    public enum LoadingPhaseType
    {
        Blocking,// Must complete before leaving loading state
        NonBlocking //can Continue in background

    }
}

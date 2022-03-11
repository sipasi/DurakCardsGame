
using Cysharp.Threading.Tasks;

using System;

using UnityEngine.SceneManagement;

namespace Framework.Shared.Services.Scenes
{
    public interface ISceneLoadingService
    {
        UniTask Load(int index, LoadSceneMode mode, IProgress<float> progress);
        UniTask Load(string name, LoadSceneMode mode, IProgress<float> progress);
    }
}

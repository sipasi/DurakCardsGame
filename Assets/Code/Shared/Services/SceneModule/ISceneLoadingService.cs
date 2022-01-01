
using System;

using Cysharp.Threading.Tasks;

using UnityEngine.SceneManagement;

namespace ProjectCard.Shared.Services.SceneModule
{
    public interface ISceneLoadingService
    {
        UniTask Load(int index, LoadSceneMode mode, IProgress<float> progress);
        UniTask Load(string name, LoadSceneMode mode, IProgress<float> progress);
    }
}

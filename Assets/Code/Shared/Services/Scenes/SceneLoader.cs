
using Cysharp.Threading.Tasks;

using Framework.Shared.Scenes;

using UnityEngine;

namespace Framework.Shared.Services.Scenes
{
    public abstract class SceneLoader : ScriptableObject
    {
        [SerializeField] private SceneReference loadScreen;

        protected ISceneLoadingService LoadingService { get; } = new SceneLoadingService();

        public abstract UniTask Load();

        protected UniTask LoadScreen() => LoadingService.Load(loadScreen);
    }
}

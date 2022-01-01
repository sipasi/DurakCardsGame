
using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCard.Shared.Services.SceneModule
{
    public readonly struct BackgroundLoading
    {
        private readonly string scene;
        private readonly LoadSceneMode mode;

        public BackgroundLoading(string scene, LoadSceneMode mode)
        {
            this.scene = scene;
            this.mode = mode;
        }

        public async UniTask<Complete> Load()
        {
            var operation = SceneManager.LoadSceneAsync(scene, mode);

            operation.allowSceneActivation = false;

            await UniTask.WaitUntil(() => operation.progress >= 0.9f);

            return new Complete(operation);
        }

        public readonly struct Complete
        {
            private readonly AsyncOperation operation;


            public Complete(AsyncOperation operation)
            {
                this.operation = operation;
            }


            public void Activate() => operation.allowSceneActivation = true;
        }
    }
}

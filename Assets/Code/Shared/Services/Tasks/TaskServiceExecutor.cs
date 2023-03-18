

using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Shared.Services.Tasks
{
    public sealed class TaskServiceExecutor : MonoBehaviour, IInitializable
    {
        private ITaskServiceAsync task;

        public void Initialize(IDiContainer container)
        {
            task = container.Get<ITaskServiceAsync>();

            Enable();
        }

        private void Awake()
        {
            if (task != null)
            {
                return;
            }

            Disable();
        }
        private void Update()
        {
            task.Execute(delta: Time.deltaTime);
        }

        public void Enable() => enabled = true;
        public void Disable() => enabled = false;
    }
}
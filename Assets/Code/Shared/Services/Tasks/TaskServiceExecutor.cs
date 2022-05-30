

using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using UnityEngine;

namespace Framework.Shared.Services.Tasks
{
    public sealed class TaskServiceExecutor : ServiceInitialization
    {
        private ITaskServiceAsync task;

        public sealed override void Initialize(IDiContainer container)
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
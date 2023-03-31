using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Durak.Game.Initializators
{
    public sealed class TaskServiceExecutor : MonoBehaviour
    {
        private ITaskServiceAsync task;

        public ITaskServiceAsync Task { get => task; set => task = value; }

        private void Awake()
        {
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
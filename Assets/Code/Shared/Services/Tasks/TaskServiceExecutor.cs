

using UnityEngine;

namespace Framework.Shared.Services.Tasks
{
    public class TaskServiceExecutor : MonoBehaviour
    {
        private ITaskServiceAsync task;

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

        public void StartTaskService(ITaskServiceAsync task)
        {
            this.task = task;

            Enable();
        }

        public void Enable() => enabled = true;
        public void Disable() => enabled = false;
    }
}
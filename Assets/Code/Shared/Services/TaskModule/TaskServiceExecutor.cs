

using UnityEngine;

namespace Framework.Shared.Services.Tasks
{
    public class TaskServiceExecutor : MonoBehaviour
    {
        [SerializeField] private TaskServiceAsync task;


        private void Update()
        {
            task.Execute(delta: Time.deltaTime);
        }


        public void Enable() => enabled = true;
        public void Disable() => enabled = false;
    }
}
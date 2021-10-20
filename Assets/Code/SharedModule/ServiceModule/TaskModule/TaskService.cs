using System;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.TaskModule
{
    [CreateAssetMenu(fileName = "TaskService", menuName = "MyAsset/Shared/ServiceModule/TaskService")]
    public sealed class TaskService : ScriptableObject, ITaskService
    {
        private readonly Queue<Task> queue = new Queue<Task>();

        public void Execute(float delta)
        {
            if (!HasAny()) return;

            var task = queue.Peek();

            task.process.Execute(delta);

            if (task.process.Finished)
            {
                Dequeue();

                if (task.HasCallback)
                {
                    task.callback.Invoke();
                }

                return;
            }
        }

        public void Add(IProcess process) => Add(process, callback: null);
        public void Add(IProcess process, Action callback) => queue.Enqueue(new Task(process, callback));

        public bool HasAny() => queue.Count > 0;

        private void Dequeue() => queue.Dequeue();


        private readonly struct Task
        {
            public readonly IProcess process;
            public readonly Action callback;

            public Task(IProcess process, Action callback)
            {
                this.process = process;
                this.callback = callback;
            }

            public bool HasCallback => callback != null;
        }
    }
}
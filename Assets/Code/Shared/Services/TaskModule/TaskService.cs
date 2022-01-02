using System.Collections.Generic;

using UnityEngine;

namespace Framework.Shared.Services.Tasks
{
    public class TaskService : ScriptableObject, ITaskService
    {
        private readonly HashSet<IProcess> hash = new HashSet<IProcess>();
        private readonly Queue<IProcess> queue = new Queue<IProcess>();

        public int Count => queue.Count;

        public void Execute(float delta)
        {
            if (!HasAny()) return;

            var process = queue.Peek();

            process.Execute(delta);

            if (process.Finished)
            {
                Dequeue();

                return;
            }
        }

        public void Add(IProcess process)
        {
            hash.Add(process);
            queue.Enqueue(process);
        }

        public bool Contains(IProcess process) => hash.Contains(process);

        public bool HasAny() => queue.Count > 0;

        public void Clear()
        {
            hash.Clear();
            queue.Clear();
        }

        private void Dequeue()
        {
            var process = queue.Dequeue();

            hash.Remove(process);
        }
    }
}
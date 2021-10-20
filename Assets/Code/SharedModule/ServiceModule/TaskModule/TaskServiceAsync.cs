using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.TaskModule
{
    [CreateAssetMenu(fileName = "TaskServiceAsync", menuName = "MyAsset/Shared/ServiceModule/TaskServiceAsync")]
    public sealed class TaskServiceAsync : ScriptableObject, ITaskServiceAsync
    {
        [SerializeField] private PlayerLoopTiming monitorTiming = PlayerLoopTiming.Update;

        private static readonly Func<IProcess, bool> processFinishedMonitor = (process) => process.Finished;

        private readonly HashSet<IProcess> hash = new HashSet<IProcess>();
        private readonly Queue<IProcess> queue = new Queue<IProcess>();


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

        public UniTask Wait(IProcess process)
        {
            if (hash.Contains(process) is false)
            {
                return UniTask.CompletedTask;
            }

            return UniTask.WaitUntilValueChanged(process, processFinishedMonitor, monitorTiming);
        }

        public bool HasAny() => queue.Count > 0;

        private void Dequeue()
        {
            var process = queue.Dequeue();

            hash.Remove(process);
        }
    }
}
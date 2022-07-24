using System;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Framework.Shared.Services.Tasks
{
    public sealed class TaskServiceAsync : TaskService, ITaskServiceAsync
    {
        [SerializeField] private PlayerLoopTiming monitorTiming = PlayerLoopTiming.Update;

        private static readonly Func<IProcess, bool> processFinishedMonitor = (process) => process.Finished;

        public UniTask Wait(IProcess process)
        {
            if (Contains(process) is false)
            {
                return UniTask.CompletedTask;
            }

            return UniTask.WaitUntilValueChanged(process, processFinishedMonitor, monitorTiming);
        }
    }
}
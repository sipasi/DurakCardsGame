
using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.ServiceModule.TaskModule
{
    public interface ITaskServiceAsync : ITaskService
    {
        UniTask Wait(IProcess process);
    }
}
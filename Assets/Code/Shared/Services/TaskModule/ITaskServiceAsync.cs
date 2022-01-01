
using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.Services.TaskModule
{
    public interface ITaskServiceAsync : ITaskService
    {
        UniTask Wait(IProcess process);
    }
}
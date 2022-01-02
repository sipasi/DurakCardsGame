
using Cysharp.Threading.Tasks;

namespace Framework.Shared.Services.Tasks
{
    public interface ITaskServiceAsync : ITaskService
    {
        UniTask Wait(IProcess process);
    }
}
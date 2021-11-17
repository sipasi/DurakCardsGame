#nullable enable 

using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.ServiceModule.SaveModule
{
    public interface ISaveService
    {
        UniTask LoadStorage();
        UniTask<bool> SaveStorage();
    }
}
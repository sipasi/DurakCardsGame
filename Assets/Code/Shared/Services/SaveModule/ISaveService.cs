

using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.Services.SaveModule
{
    public interface ISaveService
    {
        UniTask LoadStorage();
        UniTask<bool> SaveStorage();
    }
}
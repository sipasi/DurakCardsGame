

using Cysharp.Threading.Tasks;

namespace Framework.Shared.Services.Saves
{
    public interface ISaveService
    {
        UniTask LoadStorage();
        UniTask<bool> SaveStorage();
    }
}
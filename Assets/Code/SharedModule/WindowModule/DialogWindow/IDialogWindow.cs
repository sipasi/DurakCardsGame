
using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.WindowModule
{
    public interface IDialogWindow<TResult>
    {
        UniTask<TResult> Show();
    }
}

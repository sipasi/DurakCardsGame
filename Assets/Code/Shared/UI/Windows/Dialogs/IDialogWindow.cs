
using Cysharp.Threading.Tasks;

namespace Framework.Shared.UI.Windows.Dialogs
{
    public interface IDialogWindow<TResult>
    {
        UniTask<TResult> Show();
    }
}

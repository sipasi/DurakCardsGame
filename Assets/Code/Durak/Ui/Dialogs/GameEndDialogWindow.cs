using Cysharp.Threading.Tasks;

using Framework.Shared.UI.Windows.Dialogs;

namespace Framework.Durak.Ui.Windows.Dialogs
{
    internal sealed class GameEndDialogWindow : IGameEndDialogWindow
    {
        private readonly DialogWindow dialog;

        public GameEndDialogWindow(DialogWindow dialog) => this.dialog = dialog;

        public UniTask<DialogResult> Show() => dialog.Show();
    }
}

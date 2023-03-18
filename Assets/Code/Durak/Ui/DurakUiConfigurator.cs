using Framework.Durak.Ui.Views;
using Framework.Durak.Ui.Windows.Dialogs;
using Framework.Shared.DependencyInjection;
using Framework.Shared.UI.Windows.Dialogs;

using UnityEngine;

namespace Framework.Durak.Ui
{
    internal class DurakUiConfigurator : MonoBehaviour, IConfigurator
    {
        [SerializeField] private DialogWindow gameEndDialog;

        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IGameEndDialogWindow>(new GameEndDialogWindow(gameEndDialog))
                .Add<IDeckUi, DeckUi>();
        }
    }
}

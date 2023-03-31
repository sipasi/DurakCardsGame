using Framework.Durak.Ui.Views;
using Framework.Durak.Ui.Windows.Dialogs;
using Framework.Shared.DependencyInjection;
using Framework.Shared.UI.Windows.Dialogs;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    internal class DurakUiConfigurator : MonoBehaviour, IIdenticalGameConfigurator
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

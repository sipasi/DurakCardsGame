using Framework.Durak.Ui.Views;
using Framework.Durak.Ui.Windows.Dialogs;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.UI.Windows.Dialogs;

using UnityEngine;

namespace Framework.Durak.Ui
{
    internal class DurakUiConfigurator : ServiceConfigurator
    {
        [SerializeField] private DialogWindow gameEndDialog;

        public override void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IGameEndDialogWindow>(new GameEndDialogWindow(gameEndDialog))
                .Add<IDeckUi, DeckUi>();
        }
    }
}
